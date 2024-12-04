using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class BloggieDbContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<BlogPost> BlogPosts { get; set; }
        public required DbSet<Tag> Tags { get; set; }
    }
}
