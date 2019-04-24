using Blog.Models;
using Blog.Repositories;
using Blog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Interfaces
{
    public interface IRepository
    {
        Story GetPost(string id);
        List<Story> GetLastStories(int Count);
        Task CreatePost(PostViewModel vm);
        Task RemovePost(string id);
        Task EditPost(PostViewModel vm);
        Task<bool> Commit();


    }
}
