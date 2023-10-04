using Microsoft.EntityFrameworkCore;

namespace BookStore.Cart.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CartEntity> Carts { get; set; }
    }
}
