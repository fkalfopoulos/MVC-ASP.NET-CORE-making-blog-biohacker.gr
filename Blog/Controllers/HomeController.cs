using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.Interfaces;
using Blog.Repositories;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        private IRepository _repo;


        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var posts = _repo.GetLastStories(10);
            return View(posts);
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View(new Story());
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Story story)
        {
            await _repo.CreatePost(story);
            await _repo.Commit();
            return Ok();
        }



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
