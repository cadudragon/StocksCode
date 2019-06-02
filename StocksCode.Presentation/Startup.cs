using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StocksCode.Application.CQRS.Users.Commands.CreateUserCommand;
using StocksCode.Application.Interfaces;
using StocksCode.Persistence;
using NSwag;
using StocksCode.Application.Infrastructure.AutoMapper;

namespace StocksCode.Presentation
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            //Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);

            //Add DbContext using SQL Server Provider
            services.AddDbContext<IStocksCodeDbContext, StocksCodeDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("StocksCodeDatabase")));

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>());

            //Add Jwt Auth layer
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(Configuration.GetSection("AppSettings:SecretKey").Value)),
                    ValidateIssuer = false,
                    //ValidIssuer = "https://issuer.example.com",
                    ValidateAudience = false,
                    //ValidAudience = "https://yourapplication.example.com",

                    ValidateLifetime = true
                });


            services.AddOpenApiDocument(document => document.DocumentName = "a");
            services.AddSwaggerDocument(document => document.DocumentName = "b");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();
            //TODO: Add protection before publish on production

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc();

            // Add middlewares to service the OpenAPI/Swagger document and the web UI

            // URLs: 
            // - http://localhost:32367/swagger/a/swagger.json
            // - http://localhost:32367/swagger/b/swagger.json
            // - http://localhost:32367/swagger

            if (!env.IsProduction()) 
            {
                app.UseSwagger(); // registers the two documents in separate routes
                app.UseSwaggerUi3(); // registers a single Swagger UI (v3) with the two documents
            }
        }
    }
}
