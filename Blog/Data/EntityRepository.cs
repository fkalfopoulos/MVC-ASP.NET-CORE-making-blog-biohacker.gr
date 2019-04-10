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
        private readonly BlogContext _context;

        public EntityRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task CreatePost(Stories story)
        {
            _context.Add(story);

            await Commit();
        }

        public Stories GetPost(string id)
        {
            return _context.Articles.FirstOrDefault(p => p.StoryId == p.StoryId);
        }

        public List<Stories> GetAllStories(string id)
        {
            return _context.Articles.ToList();

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
