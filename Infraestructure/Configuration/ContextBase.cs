using Entites;
using Entites.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Configuration
{
   public class ContextBase: DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options): base(options){ }

        public DbSet<User> User { get; set; }
        public DbSet<Telephone> Telephone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }
       
    }
}
