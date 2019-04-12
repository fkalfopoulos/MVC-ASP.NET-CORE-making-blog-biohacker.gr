using Blog.Interfaces;
using Blog.Models;
using Blog.Repositories;
using System;
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

        public async Task CreatePost(Story story)
        {
            _context.Add(story);

            await Commit();
        }

        public Story GetPost(string id)
        {
            return _context.Stories.FirstOrDefault(p => p.StoryId == p.StoryId);
        }

        public List<Story> GetLastStories(int Count)
        {
            return _context.Stories
                .OrderByDescending(article => article.CreationTime)
                .Take(Count)
                .ToList();
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RemovePost(string id)
        {
            _context.Remove(id);
            await Commit();
        }

        public async Task EditPost(string id)
        {
            _context.Entry(id);
            await Commit();
        }

    }
}
