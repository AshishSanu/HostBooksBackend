using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HostBooks.Data.Models;
using HostBooks.Repos.UnitOfWorkInterface;
using HostBooks.Repos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HostBooks.Repos.Interfaces;
using HostBooks.Repos.Services;

namespace HostBooks.API
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
            
            services.Configure<ApplicationSetting>(Configuration.GetSection("ApplicationSetting"));

            services.AddControllers();

            services.AddDbContext<HostBooksContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); 

            services.AddCors();

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(Repos.Interfaces.IRepository<>), typeof(Repos.GenericRepository<>));
            services.AddScoped(typeof(IUsers), typeof(UsersService));
            services.AddScoped(typeof(IBulkRecords), typeof(BulkRecordService));

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseCors(options =>
            options.WithOrigins("http://localhost:44341", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseMvc();
        }
    }
}
