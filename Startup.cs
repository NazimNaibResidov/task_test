using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using Test_Task.WebUI.Core;
using Test_Task.WebUI.Data;

namespace Test_Task.WebUI
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration _Configuration)
        {
            this.Configuration = _Configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthorization(options =>
            {

                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Administrators");
                    });

            });



            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Main")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options=> {
                

                Services.Options(options);
                
            })
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>
                
                ().AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
          
            
            
            app.UseStaticFiles();
            app.UseStatusCodePages();
            
            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                   Path.Combine(env.ContentRootPath, "node_modules")
               ),
                RequestPath = "/node_modules",
                EnableDirectoryBrowsing = false
            });
            Seed.Seeder(app);
            app.UseAuthentication();
           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
         
        }
    }
}
