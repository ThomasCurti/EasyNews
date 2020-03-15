using AutoMapper;
using Backend.Dbo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System;

namespace Backend
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
            /*
             options =>
             {
             options.AddPolicy("AllowMyOrigin",
             builder => builder.WithOrigins("http://mysite.com"));
             });
             */

            services
                .AddDbContext<DataAccess.EFModels.earlynews_testContext>(options => options.UseMySql(Configuration["ConnectionStrings:Default"]));

            services.AddAutoMapper(typeof(DataAccess.AutomapperProfiles));

            services.AddCors(options => {
                options.AddPolicy("AllowAll", 
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            services.AddControllers();

            services.AddTransient<DataAccess.ArticleRepository>();

            //dependency-injected into Controller class
            //services.AddTransient<AppDb>(_ => new AppDb(Configuration["ConnectionStrings:Default"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Logger.LoggerFactory.AddFile("Log", DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "-Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
