using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Story
    {
        public Story()
        {
            Likes = new List<Like>();
            Categories = new List<Category>();
            Comments = new List<Comment>();
            Photos = new List<Photo>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public IList<Photo> Photos { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime LastEditTime { get; set; }

        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tag> Tags { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}