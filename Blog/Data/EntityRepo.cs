using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data
{
    public class EntityRepo

    {
       
        private readonly BlogContext _context;

        public EntityRepo(BlogContext context)
        {
            context = _context;
        }

        public async Task Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
            await Commit();
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
            
    }
}
