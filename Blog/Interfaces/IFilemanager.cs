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
        FileStream Imagestream(string image);
        Task<string> SaveImage(IFormFile image);
    }
}
