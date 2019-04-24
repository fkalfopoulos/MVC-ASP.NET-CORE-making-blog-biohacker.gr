using Blog.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DTOs
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }

        public IFormFile MainPhoto { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastEditTime { get; set; }

        public List<Tag> Tags { get; set; }

        public ICollection<Category> Categories { get; set; }

        public BlogPostDTO()
        {
            CreationTime = DateTime.Now;
            LastEditTime = DateTime.Now;
        }
    }
}
