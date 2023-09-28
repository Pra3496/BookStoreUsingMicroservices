using Microsoft.EntityFrameworkCore;

namespace Bookstore.Book.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookEntity> Books { get; set; }
    }
}
