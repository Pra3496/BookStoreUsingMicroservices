using Microsoft.EntityFrameworkCore;

namespace BookStore.Order.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }
        public DbSet<OrderEntity> Orders { get; set; }
    }
}
