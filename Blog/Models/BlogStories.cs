using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Stories 
    {
        public Stories()
        {
            Likes = new List<Like>();
            Categories = new List<Categories>();
            Comments = new List<Comments>();
        }
        public string StoryId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public long CreationTime { get; set; }
        public long LastEditTime { get; set; }
        public long PublishTime { get; set; }
       
        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comments>Comments { get; set; }
       public List<string> Tags { get; set; }

        public ICollection<Categories> Categories { get; set; }
    }
}