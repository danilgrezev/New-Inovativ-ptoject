using Backend6.Models;
using DoNothing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend6.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
