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
        void Add<T>(T Entity) where T : class;
        void Delete<T>(T Entity) where T : class;
        Story GetPost(int id);
        List<Story> GetLastStories(int Count);
        
        Task EditPost(PostViewModel vm);
        Task<bool> Commit();
        Photo GetPhoto(int id);
    }
}
