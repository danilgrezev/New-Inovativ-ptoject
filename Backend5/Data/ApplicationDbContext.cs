using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUserTaskType>().HasKey(x => new { x.ApplicationUserId, x.TaskTypeId });
            builder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
        }


        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Card> Cards { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationUserTaskType> ApplicationUserTaskTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Insurance> Insurances { get; set; }

        public DbSet<MyTask> Task { get; set; }

        public DbSet<IdentityUserClaim<String>> IdentityUserClaims { get; set; }
        
      public DbSet<IdentityUserRole<String>> IdentityUserRoles { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }



    }
}
