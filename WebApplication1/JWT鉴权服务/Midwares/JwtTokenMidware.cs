using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.JWT鉴权服务.Dtos;
using WebApplication1.JWT鉴权服务.Extends;
using WebApplication1.JWT鉴权服务.IServices;

namespace WebApplication1.JWT鉴权服务.Midwares
{
    public class JwtTokenMidware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        //public IJwtService _jwtService;
        //public HttpContext _httpContext;

        public JwtTokenMidware(RequestDelegate next, /*IJwtService jwtService,*/ IHttpContextAccessor httpContext, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;

            //_jwtService = jwtService;
            //_httpContext = httpContext.HttpContext;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 在处理请求之前执行的逻辑
            Console.WriteLine("Custom Middleware: Before handling the request");

            context.Request.Headers.TryGetValue("Authorization", out var bearerToken);
            if (bearerToken.Count > 0)
            {
                string token = bearerToken.First()!;
                if (JwtHelper.CheckTokenCanRead(token))
                {
                    token = token.Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);
                    var secretToken = _configuration.GetSection("Jwt:Key").Value;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    JwtSecurityToken jwtSecurity = tokenHandler.ReadJwtToken(token);
                    var expTime = jwtSecurity.Claims.FirstOrDefault(item => item.Type == "exp")?.Value;
                    var issue = jwtSecurity.Claims.FirstOrDefault(item => item.Type == "iss")?.Value;
                    var aut = jwtSecurity.Claims.FirstOrDefault(item => item.Type == "aud")?.Value;
                    if (issue == _configuration.GetSection("Jwt:Issuer").Value && aut == _configuration.GetSection("Jwt:Audience").Value)
                    {
                        if (TimeHelper.GetTimeSecondsStamp(DateTime.Now) >= Convert.ToInt32(expTime))
                        {
                            var newToken = GetJwtRefreshToken(jwtSecurity.Claims.ToList(), 2);
                            context.Response.StatusCode = 401;
                            context.Response.Headers.Add("Token", "token is expire");
                            context.Response.Headers.Add("NewToken", newToken);
                            return;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        context.Response.Headers.Add("Token", "token is invalid");
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    context.Response.Headers.Add("Token", "token is invalid");
                    return;
                }
                await _next(context);
                // 在处理请求之后执行的逻辑
                Console.WriteLine("Custom Middleware: After handling the request");
            }
            else
            {
                await _next(context);
            }
        }


        private string GetJwtRefreshToken(List<Claim> claims, int addMinutes)
        {
            //生成一个刷新令牌
            var expTime = claims.FirstOrDefault(item => item.Type == "exp")?.Value;
            expTime = TimeHelper.GetTimeSecondsStamp(DateTime.Now.AddMinutes(2)).ToString();
            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretToken));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(addMinutes),
                signingCredentials: cred);

            var jwttoken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwttoken;
        }
    }
}
