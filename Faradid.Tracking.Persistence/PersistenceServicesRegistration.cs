using Faradid.Tracking.Application.Interfaces.Repository.Common;
using Faradid.Tracking.Application.Interfaces.Repository;
using Faradid.Tracking.Interfaces.Identity;
using Faradid.Tracking.Identity.Models;
using Faradid.Tracking.Application.Services;
using Faradid.Tracking.Persistence.Context;
using Faradid.Tracking.Persistence.Repositories;
using Faradid.Tracking.Persistence.Repositories.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Faradid.Tracking.Persistence
{
    public static class PersistenceServicesRegistration
    {

        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TrackingDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("ConnectionString"));
            });
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<TrackingDbContext>().AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthService>();
            //services.AddTransient<IUserService,UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }


    }
}
