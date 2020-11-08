using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Todo.Core;
using MediatR;
using Todo.Backend.Initial;
using AutoMapper;
using Todo.Backend.Infrastructure;
using Todo.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Todo.Backend.Infrastructure.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Todo.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = typeof(Startup).Assembly;

            services.AddControllers();

            services.AddSingleton(provider =>
            {
                var rsa = RSA.Create();

                rsa.ImportRSAPublicKey(
                    source: Convert.FromBase64String(Configuration["PublicKey"]),
                    bytesRead: out int _
                    );

                return new RsaSecurityKey(rsa);
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);

            services.AddAutoMapper(assembly, typeof(Infrastructure.Injection).Assembly);
            services.AddSwaggerGen();

            services.AddCore();

            services.AddIdentity<Account, AccountRole>();

            services.AddInfrastructure();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer("Asymmetric", options =>
                    {
                        SecurityKey rsa = services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();

                        options.IncludeErrorDetails = true;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            IssuerSigningKey = rsa,
                            ValidAudience = "https://localhost:4200",
                            ValidIssuer = "https://localhost:11000",
                            RequireSignedTokens = true,
                            RequireExpirationTime = true,
                            ValidateLifetime = true,
                            ValidateAudience = true,
                            ValidateIssuer = true
                        };
                    });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseCors(policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}