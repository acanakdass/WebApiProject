using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Core.Repositories;
using WebApiProject.Core.Services;
using WebApiProject.Core.UnitOfWork;
using WebApiProject.DataAccess.Concrete.EfCore.Context;
using WebApiProject.DataAccess.Concrete.EfCore.Repositories;
using WebApiProject.DataAccess.Concrete.EfCore.UnitOfWork;
using WebApiProject.Service.Services;

namespace WebApiProject.API
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
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(EfEntityRepositoryBase<>));
            services.AddScoped(typeof(IService<>), typeof(BaseManager<>));
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<WebApiProjectContext>(options=>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlServerConString"].ToString(), opt =>
                {
                    opt.MigrationsAssembly("WebApiProject.DataAccess");
                });

                //Sqlite Connection
                //options.UseSqlite(Configuration["ConnectionStrings:SqLiteConString"].ToString(), opt =>
                //{
                //    opt.MigrationsAssembly("WebApiProject.DataAccess");
                //});
            });
            services.AddControllers();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
