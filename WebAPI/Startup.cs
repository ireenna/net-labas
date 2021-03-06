using AutoMapper;
using BLL.MappingProfiles;
using BLL.ModelsDTO;
using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using FluentValidation;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<BookingProfile>();
                cfg.AddProfile<ClientProfile>();
                cfg.AddProfile<RoomProfile>();
                cfg.AddMaps(GetType().Assembly);
            });
            Assembly.GetExecutingAssembly();

            services.AddScoped<IValidator<BookingDTO>, BookingDTOValidator>();
            services.AddTransient<IUnitOfWork, UnitOfWork<HotelContext>>();

            services.AddScoped<IClientService, ClientsService>();
            services.AddScoped<IRoomService, RoomsService>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddDbContext<HotelContext>(options => options.UseSqlServer("Server=DESKTOP-RG3R0BI\\SQLEXPRESS;Database=NETlaba;Trusted_Connection=True;"));
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
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
