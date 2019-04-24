using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Interfaces
{
    public interface IFilemanager
    {
        string GetImagePath(int storyId);
        Task<string> SaveImage(IFormFile image);
    }
}
