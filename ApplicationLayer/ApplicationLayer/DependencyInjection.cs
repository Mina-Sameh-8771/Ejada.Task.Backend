using ApplicationLayer.Config;
using ApplicationLayer.Interface;
using ApplicationLayer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer
{
    public static class DependencyInjection
    {
        public static void AddApplicationLayer(this IServiceCollection services , IConfiguration Configuration)
        {
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IMailService, MailService>();

            services.Configure<MailConfig>(Configuration.GetSection("MailConfig"));
            services.Configure<PasswordGenerationConfig>(Configuration.GetSection("PasswordGenerationConfig"));


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
        }
    }
}
