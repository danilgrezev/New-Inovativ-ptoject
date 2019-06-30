using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend5.Data;
using Backend5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Backend5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

        }

        private async Task ConfigureIdentity(IServiceScope scope)
        {
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            var adminsRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrators);
            if (adminsRole == null)
            {
                var roleResult = await roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Administrators));
                if (!roleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unable to create {ApplicationRoles.Administrators} role.");
                }

                adminsRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrators);
            }

            var adminUser = await userManager.FindByNameAsync("admin@localhost.local");
            if (adminUser == null)
            {
                var userResult = await userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "admin@localhost.local",
                    Email = "admin@localhost.local"
                }, "AdminPass123!");
                if (!userResult.Succeeded)
                {
                    throw new InvalidOperationException($"Unable to create admin@localhost.local user");
                }

                adminUser = await userManager.FindByNameAsync("admin@localhost.local");
            }

            if (!await userManager.IsInRoleAsync(adminUser, adminsRole.Name))
            {
                await userManager.AddToRoleAsync(adminUser, adminsRole.Name);
            }
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
            {
                context.Database.Migrate();
                //  this.ConfigureIdentity(scope).GetAwaiter().GetResult();





                var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                var adminsRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrators);
                if (adminsRole == null)
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Administrators));
                    if (!roleResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Unable to create {ApplicationRoles.Administrators} role.");
                    }

                    adminsRole = await roleManager.FindByNameAsync(ApplicationRoles.Administrators);
                }

                var adminUser = await userManager.FindByNameAsync("admin@localhost.local");
                if (adminUser == null)
                {
                    var userResult = await userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin@localhost.local",
                        Email = "admin@localhost.local"
                    }, "AdminPass123!");
                    if (!userResult.Succeeded)
                    {
                        throw new InvalidOperationException($"Unable to create admin@localhost.local user");
                    }

                    adminUser = await userManager.FindByNameAsync("admin@localhost.local");
                }

                if (!await userManager.IsInRoleAsync(adminUser, adminsRole.Name))
                {
                    await userManager.AddToRoleAsync(adminUser, adminsRole.Name);
                }







            }


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
