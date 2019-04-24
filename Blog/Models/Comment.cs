using System;

namespace Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }

        public User User;
        public int UserId { get; set; }
        public Story Story;
        public int StoryId { get; set; }
    }
}
