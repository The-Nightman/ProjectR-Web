using Microsoft.EntityFrameworkCore;
using ProjectR_Web.Server.Entities;

namespace ProjectR_Web.Server.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<Media> Media { get; set; }
    }
}
