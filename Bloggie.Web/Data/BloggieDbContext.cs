using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext(DbContextOptions<BloggieDbContext> options) : DbContext(options)
    {
        public required DbSet<BlogPost> BlogPosts { get; set; }
        public required DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLike { get; set; }

        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
