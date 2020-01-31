using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Test_Task.WebUI.Data;

namespace Test_Task.WebUI.Core
{
    public class SeedTools
    {
        public static void SeedRoles
   (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
        ("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
               
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


          
        }
        public static void SeedUsers
(UserManager<ApplicationUser> userManager)
        {
            if (userManager.Users.Count()==0)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Naib";
                user.PhoneNumberConfirmed = true;
                user.EmailConfirmed = true;
                user.Email = "residovnaib@gmail.com";
               IdentityResult result = userManager.CreateAsync
                (user, "7505020r").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }
        }
        }
}
