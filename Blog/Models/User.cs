using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class User 
    {
        public User()
        {
            Stories = new List<Stories>();
            Likes = new List<Like>();
            
            Comments = new List<Comments>();
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Stories> Stories { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comments> Comments { get; set; }

       
    }
}
