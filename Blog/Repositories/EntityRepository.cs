using Blog.Interfaces;
using Blog.Models;
using Blog.Repositories;
using Blog.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class EntityRepository : IRepository

    {
        private BlogContext _context;


        public EntityRepository(BlogContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            _context.Remove(Entity);
        }

        public async Task SavePhotoData(PostViewModel vm)
        {
            _context.Add(vm);

            await Commit();
        }

        public Story GetPost(int id)
        {
            return _context.Stories.FirstOrDefault(p => p.Id == id);
        }

        public Photo GetPhoto(int id)
        {
            return _context.Photos.FirstOrDefault(p => p.Id == id);
        }

        public List<Story> GetLastStories(int Count)
        {
            return _context.Stories
                .Include(str => str.Photos)
                .OrderByDescending(article => article.CreationTime)
                .Take(Count)
                .ToList();
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }    


        public async Task EditPost(PostViewModel vm)
        {
            _context.Entry(vm);
            await Commit();
        }

    }
}
