using Microsoft.AspNetCore.Http;
using System;

namespace Blog.DTOs
{
    public class PhotoDTO
    {
        public string PublicId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public IFormFile File { get; set; }

        public PhotoDTO()
        {
            DateAdded = DateTime.Now;
        }
    }
}