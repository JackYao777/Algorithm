using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using WebApplication1.JWT鉴权服务.Context;
using WebApplication1.JWT鉴权服务.IServices;
using WebApplication1.JWT鉴权服务.Services;
using Snowflake.Core;
using WebApplication1.JWT鉴权服务.Extends;

namespace WebApplication1.JWT鉴权服务
{
    /// <summary>
    /// 注入JWTToken验证方式
    /// </summary>
    public static class JWTConfigExtensions
    {
        public static AuthenticationBuilder AddAuthcations(this WebApplicationBuilder builder)
        {
            #region 注入所需服务以及数据库,缓存,以及雪花Id
            builder.Services.AddDbContext<JwtDemoDbContext>(options =>
            options.UseMySql(builder.Configuration.GetConnectionString("JwtDemoDatabase"), new MySqlServerVersion(new Version("8.0.30"))));
            builder.Services.AddScoped<IJwtRepository, JwtRepository>();
            builder.Services.AddScoped<IAccountsService, AccountsService>();
            builder.Services.AddScoped<IJwtService, JwtService>();

            builder.Services.AddMemoryCache();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSingleton<IdWorker>(new IdWorker(new Random().Next(1, 30), new Random().Next(1, 30)));

            #endregion


            #region 注入鉴权服务
            return builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                   ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
               };
           });
            #endregion 
        }
    }
}
