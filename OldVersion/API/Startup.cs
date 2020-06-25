using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Domain;
using Application.Projects;
using Microsoft.AspNetCore.Authentication;
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
using Persistence;
using Microsoft.AspNetCore.Identity;
using Domain.Users;
using API.Middleware;
using Application.Interfaces;
using Infrastructure.Security;

namespace API
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

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("Default"));
            });
            // services.AddDefaultIdentity<User>()
            //     .AddEntityFrameworkStores<DataContext>();

            // services.AddIdentityServer()
            //     .AddApiAuthorization<User, DataContext>();

            // services.AddAuthentication()
            //     .AddIdentityServerJwt();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            services.AddAutoMapper(typeof(ProjectMappings).Assembly);
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("DiscountJiraApiSpec", new OpenApiInfo()
                {
                    Title = "Discount Jira",
                    Version = "1",
                    Description = "Public API for controlling your project base."
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IProjectService, ProjectService>();

            var builder = services.AddIdentityCore<User>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<DataContext>(); // pass in our data context
            identityBuilder.AddSignInManager<SignInManager<User>>(); // to be able to use username and password

            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (env.IsDevelopment()) { }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/DiscountJiraApiSpec/swagger.json", "Discount Jira");
                opt.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            // app.UseAuthentication();
            app.UseAuthorization();


            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}