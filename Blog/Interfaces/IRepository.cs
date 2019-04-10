using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Interfaces
{
   public interface IRepository
    {
        Stories GetPost(string id);
        List<Stories> GetAllStories();
        Task CreatePost(Stories story);
        Task RemovePost(string id);
        Task EditPost(string id);
        Task<bool> Commit();


    }
}
