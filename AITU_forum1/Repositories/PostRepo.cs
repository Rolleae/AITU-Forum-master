using AITU_forum1.Data;
using AITU_forum1.Dtos;
using AITU_forum1.Models;
using AITU_forum1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly DataContext _context;

        public PostRepo(DataContext context)
        {
            _context = context;
        }

        public bool AddPost(Post post)
        {
            _context.PostList.Add(post);
            return _context.SaveChanges() > 0;
        }

        public bool DeletePost(Guid id)
        {
            var post =_context.PostList.FirstOrDefault(x => x.Id == id);
            if(post != null)
            {
                _context.PostList.Remove(post);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Post GetPostById(Guid id)
        {
            return _context.PostList.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Post> GetPosts()
        {
            return _context.PostList.OrderBy(x => x.Name);
        }

        public bool UpdatePost(Post post)
        {
            return true;
        }
    }
}
