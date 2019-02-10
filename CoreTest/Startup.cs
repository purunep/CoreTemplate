using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreTest.Data;
using CoreTest.Data.Entities;
using CoreTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CoreTest
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<CoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<CoreContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(
                cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });


            services.AddDbContext<CoreContext>(cfg =>
            {
                cfg.UseSqlServer(_config.GetConnectionString("CoreConnectionString"));
            });
            services.AddAutoMapper();

            services.AddTransient<CoreSeeder>();

            services.AddTransient<IMailService, LoggerMailService>();

            services.AddScoped<ICoreRepository, CoreRepository>();

            services.AddMvc().AddJsonOptions
                (option => option.SerializerSettings.ReferenceLoopHandling
                = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseNodeModules(env);
            app.UseMvc(cfg =>
                {
                    cfg.MapRoute("Default", "/{controller}/{action}/{id?}",
                        new { controller = "App", Action = "Index" });
                });
        }
    }
}
