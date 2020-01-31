using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Test_Task.WebUI.Data;

namespace Test_Task.WebUI.Core
{
    public class Seed
    {

        private  void SeedUser(IApplicationBuilder app)
        {
            ApplicationIdentityDbContext context = app.ApplicationServices.GetRequiredService<ApplicationIdentityDbContext>();
            context.Database.Migrate();
            var userMager = app.ApplicationServices.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();
            SeedTools.SeedRoles(roleManager);
            SeedTools.SeedUsers(userMager);
        }
        public static void Seeder(IApplicationBuilder app)
        {
            Seed seed = new Seed();
            seed.SeedUser(app);
        }
    }
}
