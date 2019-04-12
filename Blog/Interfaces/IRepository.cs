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
        Story GetPost(string id);
        List<Story> GetLastStories(int Count);
        Task CreatePost(Story story);
        Task RemovePost(string id);
        Task EditPost(string id);
        Task<bool> Commit();


    }
}
