using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class CreateStoryViewModel
    {
        public IFormFile StoryImage { get; set; }

        [Required]
        public string StoryBody { get; set; }

        [Required]
        public List<string> Category { get; set; }
    }
}

    public class EditStoryViewModel

    {

    public IFormFile StoryImage { get; set; }

    [Required]
    public string StoryBody { get; set; }

    [Required]
    public List<string> Category { get; set; }
    }
