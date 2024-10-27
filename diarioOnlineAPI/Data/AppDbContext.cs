using diarioOnlineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace diarioOnlineAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DiaryEntries> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiaryEntries>().ToTable("DiaryEntries", "dbo");
        }
    }
}