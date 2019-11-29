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

            services.AddTransient<IDiscountAppService, DiscountAppService>();
            services.AddTransient<IFeedbackAppService, FeedbackAppService>();
            services.AddTransient<IMenuAppService, MenuAppService>();
            services.AddTransient<IOrderAppService, OrderAppService>();
            services.AddTransient<IPaymentAppService, PaymentAppService>();
            services.AddTransient<IRegularGuestAppService, RegularGuestAppService>();
            services.AddTransient<ITableAppService, TableAppService>();


            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IRegularGuestRepository, RegularGuestRepository>();
            services.AddTransient<ITableRepository, TableRepository>();
            

            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

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

            app.UseCors("MyPolicy");

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
