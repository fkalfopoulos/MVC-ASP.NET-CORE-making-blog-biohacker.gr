using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Share
    {
        public string StoryId { get; set; }
        public Stories Story { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}