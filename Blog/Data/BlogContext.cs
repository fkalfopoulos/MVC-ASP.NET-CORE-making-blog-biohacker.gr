using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    public class BlogContext : DbContext

    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }


        public DbSet<Stories> Articles { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stories>()
               .HasKey(s => s.StoryId);

            modelBuilder.Entity<Comments>()
                 .HasKey(c => c.CommentId);

            modelBuilder.Entity<Like>()
                .HasKey(l => l.StoryId);
            
        }
    }
}
