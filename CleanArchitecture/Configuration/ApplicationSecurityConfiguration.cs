﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace CleanArchitecture.Configuration
{
    public static class ApplicationSecurityConfiguration
    {
        public static IServiceCollection ConfigureApplicationSecurity(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;
            services.AddHttpContextAccessor();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = configuration.GetSection("Security.Bearer:Authority").Get<string>();
                        options.Audience = configuration.GetSection("Security.Bearer:Audience").Get<string>();

                        options.TokenValidationParameters.RoleClaimType = "role";
                        options.SaveToken = true;
                    });

            services.AddAuthorization(ConfigureAuthorization);

            return services;
        }


        private static void ConfigureAuthorization(AuthorizationOptions options)
        {
            //Configure policies and other authorization options here. For example:
            //options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("role", "employee"));
            //options.AddPolicy("AdminOnly", policy => policy.RequireClaim("role", "admin"));
        }
    }
}
