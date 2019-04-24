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
using Blog.DTOs;

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
            var stories = posts.Select(str => new StoryDTO
            {
                Id = str.Id,
                Title = str.Title,
                Description = str.Description,
                ImageSrc = str.Photos.First(ph => ph.IsMain).Url
            }).ToList();
            return View(stories);
        }

        public IActionResult Post(PostViewModel vm)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostDTO PostData)
        {
            string FilePath = await _filemanager.SaveImage(PostData.MainPhoto);
            Story NewStory = new Story
            {
                Title = PostData.Title,
                Description = PostData.Description,
                Body = PostData.Body,
                Tags = PostData.Tags
            };
            _repo.Add(NewStory);

            var NewPhoto = new Photo
            {
                Url = FilePath,
                Description = "Descriptive Photo",
                IsMain = true
            };
            if (await _repo.Commit())
            {
                NewStory.Photos.Add(NewPhoto);

                if (await _repo.Commit())
                {
                    return CreatedAtRoute(
                            nameof(HomeController.GetPhoto),
                            new { id = NewPhoto.Id });
                }

                return BadRequest("Could not save the photo");
            }
            return BadRequest("Could not save the story");
        }


        [HttpGet("id", Name = "GetPhoto")]
        public IActionResult GetPhoto(int Id)
        {
           return Ok(_filemanager.GetImagePath(Id));
        }
        

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var post = _repo.GetPost(Id);

            return View(new PostViewModel
            {
                Title = post.Title,
                Description = post.Description,
                Body = post.Body
            });

        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(BlogPostDTO PostData)
        //{
        //    string ImageName = await _filemanager.SaveImage(PostData.MainPhoto);
        //    var post = (new Story
        //    {
        //        StoryId = PostData.StoryId,
        //        Title = PostData.Title,
        //        Description = PostData.Description,
        //        Body = PostData.Body,
        //        Photo = PostData.Photo
        //    });
        //    if (PostData.StoryId != null)
        //        await _repo.EditPost(PostData);
        //    else await _repo.CreatePost(PostData);

        //    return RedirectToAction();
        //}

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
