using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public User User;
        public int UserId { get; set; }
        public Story Story;
        public int StoryId { get; set; }

    }
}
