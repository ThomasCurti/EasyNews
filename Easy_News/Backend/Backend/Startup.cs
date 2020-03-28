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

            string connectionString = Configuration["ConnectionStrings:Default"];

            AppDb db = new AppDb(connectionString);
            try
            {
                db.Connection.Open();
                db.Connection.Close();
            }
            catch
            {
                connectionString = "server=mariadb;user=root;port=3306;password=admin;database=earlynews_test";
            }

            services
                .AddDbContext<DataAccess.EFModels.earlynews_testContext>(options => options.UseMySql(connectionString));

            services.AddAutoMapper(typeof(DataAccess.AutomapperProfiles));

            services.AddCors(options => {
                options.AddPolicy("AllowAll", 
                    builder => builder.AllowAnyOrigin()
                                      .WithMethods("GET", "HEAD")
                                      .AllowAnyHeader());
            });

            services.AddControllers();

            services.AddTransient<DataAccess.ArticleRepository>();
            services.AddTransient<DataAccess.ArticleSourceRepository>();
            services.AddTransient<DataAccess.DubiousArticleRepository>();
            services.AddTransient<DataAccess.EventRepository>();
            services.AddTransient<DataAccess.EventTypeRepository>();
            services.AddTransient<DataAccess.LogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Logger.Logger.AddFile("Log", DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + "-Log.txt");

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
