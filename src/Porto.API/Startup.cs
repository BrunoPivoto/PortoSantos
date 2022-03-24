using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Porto.API.ViewModels;
using Porto.Domain.Entities;
using Porto.Infra.Context;
using Porto.Infra.Interfaces;
using Porto.Infra.Repositories;
using Porto.Services.DTO;
using Porto.Services.Interfaces;
using Porto.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Porto.API
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

            services.AddControllers();

            #region  AutoMapper
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Container, ContainerDTO>().ReverseMap();
                cfg.CreateMap<CreateContainerViewModel, ContainerDTO>().ReverseMap();
                cfg.CreateMap<Movement, MovementDTO>().ReverseMap();
                cfg.CreateMap<CreateMovementViewModel, MovementDTO>().ReverseMap();
                cfg.CreateMap<UpdateContainerViewModel, ContainerDTO>().ReverseMap();
            });

            services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion 

            #region DI
            services.AddScoped<IContainerService, ContainerService>();
            services.AddScoped<IContainerRepository, ContainerRepository>();
            services.AddScoped<IMovementService, MovementService>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddSingleton(d => Configuration);
            services.AddDbContext<PortoContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:PORTO_API"]), ServiceLifetime.Transient);
            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.4", new OpenApiInfo
                {
                    Title = "Porto API",
                    Version = "v1.4",
                    Description = "API construída para processo seletivo usando .NET .",
                    Contact = new OpenApiContact
                    {
                        Name = "Bruno Pivoto Rangel",
                        Email = "brunorangel@gec.inatel.br",
                        Url = new Uri("https://www.linkedin.com/in/bruno-pivoto-rangel/")
                    },
                });

            });

            #endregion

        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.4/swagger.json", "Porto.API v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
}
