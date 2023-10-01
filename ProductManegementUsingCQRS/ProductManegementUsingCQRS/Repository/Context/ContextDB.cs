using Microsoft.EntityFrameworkCore;

namespace ProductManegementUsingCQRS.Repository.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ProductEntity> Products { get; set; }


    }
}
