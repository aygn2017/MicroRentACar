using MicroRentACar.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRentACar.Data
{
    public class MicroDBContext : DbContext
    {
        public MicroDBContext(DbContextOptions<MicroDBContext> options) : base(options)
        {

        }
        public virtual DbSet<Role> Roles{ get; set; }
        public virtual DbSet<User> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}
