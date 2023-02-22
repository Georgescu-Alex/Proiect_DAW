using Microsoft.EntityFrameworkCore;
using ProiectDAW.Models;

namespace ProiectDAW.ContextModels
{
    public class ArticlesContext : DbContext
    {
        public ArticlesContext(DbContextOptions<ArticlesContext> options) : base(options) { }

        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
