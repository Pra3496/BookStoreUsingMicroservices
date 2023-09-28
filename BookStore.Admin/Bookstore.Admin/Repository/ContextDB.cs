using Microsoft.EntityFrameworkCore;

namespace Bookstore.Admin.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AdminEntity> Admin { get; set; }
    }
}
