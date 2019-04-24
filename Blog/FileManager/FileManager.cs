using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Blog.Interfaces;

namespace Blog.FileManager
{
    public class Filemanager : IFilemanager
    {
        private readonly string _imagePath;

        public Filemanager(IConfiguration config)
        {
            _imagePath = config["Path.Images"];
        }

        public FileStream  Imagestream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image) , FileMode.Open , FileAccess.Read);
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                var save_path = Path.Combine(_imagePath);
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }               

                var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

                using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Error";

            }

        }
    }
}
