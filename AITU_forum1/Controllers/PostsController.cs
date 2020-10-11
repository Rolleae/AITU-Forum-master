using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AITU_forum1.Dtos;
using AITU_forum1.Models;
using AITU_forum1.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITU_forum1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepo _postRepo;

        public PostsController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }
        [Authorize(Roles = "LeaderOfGroup,SimpleStudent")]
        [HttpGet]
        public ActionResult<ICollection<PostDto>> GetPosts()
        {
            IEnumerable<Post> innerPosts = _postRepo.GetPosts();
            ICollection<PostDto> posts = new LinkedList<PostDto>();

            foreach (Post p in innerPosts)
            {
                posts.Add(new PostDto()
                {
                    Name = p.Name,
                    Description = p.Description,
                    Text = p.Text
                });
            }
            return Ok(posts);
        }
        [Authorize(Roles = "LeaderOfGroup,SimpleStudent")]
        [HttpPost("add")]
        public ActionResult AddPost(PostDto post)
        {
            Post p = new Post(post);
            if (_postRepo.AddPost(p))
            {
                return Ok(p);
            }
            return BadRequest("Some problem occured during adding the new post");
        }
        [Authorize(Roles = "LeaderOfGroup")]
        [HttpPost("delete")]
        public ActionResult DeletePost(Guid id)
        {
            if (_postRepo.DeletePost(id))
            {
                return Ok("Post was deleted");
            }
            return BadRequest("Some problem occured during deletion the post");
        }
        [HttpGet("{id}")]
        public ActionResult GetPostById(Guid id)
        {
            if (_postRepo.GetPostById(id) != null)
            {
                return Ok(_postRepo.GetPostById(id));
            }
            return BadRequest("No post was found!");
        }
        [HttpPost("update")]
        public ActionResult UpdatePost(Post post)
        {
            if (_postRepo.UpdatePost(post))
            {
                return Ok("Post has been updated");
            }
            return BadRequest("Problem with updating the post");
        }
    }
}
