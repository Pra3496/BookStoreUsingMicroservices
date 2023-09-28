//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bookstore.User.Repository
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
    }
}
