using AITU_forum1.Dtos;
using AITU_forum1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Repositories.Interfaces
{
    public interface IPostRepo
    {
        IQueryable<Post> GetPosts();
        bool AddPost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(Guid id);
        Post GetPostById(Guid id);
    }
}
