using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nav.Services.DBConfigAPI.DbContexts;
using Nav.Services.DBConfigAPI.IServices;
using Nav.Services.DBConfigAPI.Repository;
using Nav.Services.DBConfigAPI.Services;

namespace Nav.Services.DBConfigAPI
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
           var data= services.AddDbContext<ApplicationDBContext>(options => options.UseInMemoryDatabase(databaseName: "TestDB"));
            services.AddScoped<ApplicationDBContext>();
            services.AddHttpClient<IBaseService, BaseService>();
            SD.CustomFieldAPIBase = Configuration["ServiceUrls:CustomAPI"];
            SD.DefaultFieldAPIBase = Configuration["ServiceUrls:DefaultAPI"];
            services.AddScoped<IDbConfigRepository, DbConfigRepository>();
            services.AddScoped<IBaseService, BaseService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            DBData.feedData(context);
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
