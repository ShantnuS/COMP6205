using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloHomes.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelloHomes
{
    public class Startup
    {

        public static string personConnString; 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();
            services.AddMvc()
                    .AddRazorPagesOptions(options => {
                        //Razor page options

                        //Authorization
                        options.Conventions.AuthorizeFolder("/Admin");
                        options.Conventions.AuthorizeFolder("/Account");
                        options.Conventions.AllowAnonymousToPage("/Account/Login");
                        options.Conventions.AllowAnonymousToPage("/Account/SignUp");
                    });

           services.AddDbContext<HelloHomesContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("HelloHomesContext")));

            personConnString = Configuration.GetConnectionString("HelloHomesPersonContext");

            services.AddDbContext<HelloHomesPersonContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("HelloHomesPersonContext")));
        
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.UseStatusCodePages();
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
        }
    }
}
