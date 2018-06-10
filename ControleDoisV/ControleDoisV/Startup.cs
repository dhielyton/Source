using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDoisV.Data;
using ControleDoisV.Models;
using DAL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleDoisV
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddDbContext<C2VContext>(options => options.UseSqlServer
             (Configuration.GetConnectionString("C2VConnection")));
             services.AddDbContext<DBContextApplication>(options => options.UseSqlServer
             (Configuration.GetConnectionString("C2VConnection")));
          
            services.AddMvc();

            services.AddIdentity<UserApplication, IdentityRole>()
             .AddEntityFrameworkStores<DBContextApplication>()
             .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/AcessarUsuario/Acessar";
                options.AccessDeniedPath = "/Infra/AcessoNegado";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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
