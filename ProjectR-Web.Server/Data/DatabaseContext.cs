using Microsoft.EntityFrameworkCore;

namespace ProjectR_Web.Server.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }
    }
}
