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
using Microsoft.OpenApi.Models;
using RestaurantAdministration.Application.AppServices;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.EF;
using RestaurantAdministration.EF.Interfaces;
using RestaurantAdministration.EF.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace RestaurantAdministration.API
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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("RADb"));

            services.AddTransient<IRegularGuestAppService, RegularGuestAppService>();
            services.AddTransient<IMenuAppService, MenuAppService>();
            services.AddTransient<ITableAppService, TableAppService>();
            services.AddTransient<IDiscountAppService, DiscountAppService>();

            services.AddTransient<IRegularGuestRepository, RegularGuestRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();

            services.AddTransient<ITableAppService, TableAppService>();
            services.AddTransient<ITableRepository, TableRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant Administration API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Administration API V1");
            });

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
