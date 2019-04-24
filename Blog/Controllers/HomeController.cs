using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Interfaces;
using Blog.Repositories;
using Microsoft.AspNetCore.Http;
using Blog.FileManager;
using Microsoft.Extensions.DependencyInjection;
using Blog.ViewModels;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        private IRepository _repo;
        private readonly IFilemanager _filemanager;
        

        public HomeController(IRepository repo, IFilemanager filemanager)
        {
            _repo = repo;
            _filemanager = filemanager;
            
        }

        public IActionResult Index()
        {
            var posts = _repo.GetLastStories(10);
            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var post = _repo.GetPost(Id);

            return View(new PostViewModel
            {
                StoryId = post.StoryId,
                Title = post.Title,
                Description = post.Description,
                Body = post.Body,
                Photo = post.Photo,
            });
            
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel vm)
        {
            var post = (new Story
            {
                StoryId = vm.StoryId,
                Title = vm.Title,
                Description = vm.Description,
                Body = vm.Body,
                Photo = vm.Photo
            });
            if (vm.StoryId != null)
                await _repo.EditPost(vm);
            else await _repo.CreatePost(vm);

            return RedirectToAction();
        }

        //[HttpGet("/image/{image}")]

        //public IActionResult Image(string image)
        //{
        //    var mine = image.Substring(image.LastIndexOf('.') + 1);
        //    return new FileStreamResult(_filemanager.Imagestream(image), $"image/{mine}");
        // }


        [HttpGet("/image/{image}")]
        public IActionResult Image(string image) =>
        new FileStreamResult(_filemanager.Imagestream(image),
        image.Substring(image.LastIndexOf('.') + 1));



          public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
