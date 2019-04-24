using System;

namespace Blog.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }

        public Story Story { get; set; }
        public int StoryId { get; set; }

        public Photo()
        {
            DateAdded = DateTime.Now;
        }
    }
}