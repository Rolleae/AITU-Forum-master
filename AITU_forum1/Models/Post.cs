using AITU_forum1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AITU_forum1.Models
{
    public class Post
    {
        public Post()
        {
        }

        public Post(PostDto post)
        {
            Id = Guid.NewGuid();
            Name = post.Name;
            Description = post.Description;
            Text = post.Text;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}
