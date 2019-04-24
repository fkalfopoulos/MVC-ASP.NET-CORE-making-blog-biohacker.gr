using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Blog.Interfaces;

namespace Blog.FileManager
{
    public class Filemanager : IFilemanager
    {
        private readonly string _imagePath;
        private readonly IRepository repo;

        public Filemanager(IConfiguration config, IRepository repo)
        {
            _imagePath = config["Path:Images"];
            this.repo = repo;
        }

        public string GetImagePath(int PhotoId)
        {
            return repo.GetPhoto(PhotoId).Url;
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            try
            {
                string save_path = Path.Combine(_imagePath);

                Directory.CreateDirectory(save_path);


                string mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
                string fileName = $"img_{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}{mime}";

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
