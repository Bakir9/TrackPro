using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<StoreContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = config.GetConnectionString("Cache");
            });

            services.AddIdentity<User, IdentityRole<int>>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireNonAlphanumeric = true;
            })
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<StoreContext>()
            .AddSignInManager<SignInManager<User>>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => 
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true,
                    };
                });
            
            services.AddAuthorization();
            
            services.AddDbContext<StoreContext>( opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
        
    }
}