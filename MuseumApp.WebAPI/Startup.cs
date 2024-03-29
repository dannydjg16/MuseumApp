﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MuseumApp.DB;
using Microsoft.AspNetCore.Mvc.Formatters;
using MuseumApp.Domain.Interfaces;
using MuseumApp.DB.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MuseumApp.WebAPI
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
            services.AddScoped<IUserInterface, UserRepository>();
            services.AddScoped<IArtistInterface, ArtistRepository>();
            services.AddScoped<IArtTypeInterface, ArtTypeRepository>();
            services.AddScoped<IArtworkInterface, ArtworkRepository>();
            services.AddScoped<ILocationInterface, LocationRepository>();
            services.AddScoped<ILocationTypeInterface, LocationTypeRepository>();
            services.AddScoped<ILikesInterface, LikesRepository>();

            services.AddControllers(options =>
            {
                // make asp.net core forget about text/plain so swagger ui uses json as the default
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                // teach asp.net core to be able to serialize & deserialize XML
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                options.ReturnHttpNotAcceptable = true;
            });


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                                            "https://dgart.azurewebsites.net",
                                            "https://grantartapplication.azurewebsites.net",
                                            "http://localhost:44399")
                            .AllowAnyMethod() // allow PUT & DELETE not just GET & POST
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            services.AddDbContext<ArtApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ArtApplication")));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = "https://dev-7824301.okta.com/oauth2/default";
                options.Audience = "api://default";
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

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
