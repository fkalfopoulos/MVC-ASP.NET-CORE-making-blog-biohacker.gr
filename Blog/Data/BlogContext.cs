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


        public DbSet<Story> Stories { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>()
               .HasKey(s => s.StoryId);

            modelBuilder.Entity<Comment>()
                 .HasKey(c => c.CommentId);

            modelBuilder.Entity<Like>()
                .HasKey(l => l.StoryId);

        }
    }
}
