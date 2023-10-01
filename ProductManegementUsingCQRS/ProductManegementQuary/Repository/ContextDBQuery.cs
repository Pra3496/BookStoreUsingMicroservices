using Microsoft.EntityFrameworkCore;
using ProductManegementUsingCQRS.Repository.Context;

namespace ProductManegementQuary.Repository
{
    public class ContextDBQuery : DbContext
    {
        public ContextDBQuery(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
