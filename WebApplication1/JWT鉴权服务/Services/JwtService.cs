using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Snowflake.Core;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication1.JWT鉴权服务.Context;
using WebApplication1.JWT鉴权服务.Dtos;
using WebApplication1.JWT鉴权服务.Extends;
using WebApplication1.JWT鉴权服务.IServices;

namespace WebApplication1.JWT鉴权服务.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        ///缓存
        /// </summary>
        private readonly IMemoryCache _memoryCache;

        private readonly IdWorker _idWorker;

        private HttpContext _httpContext;

        public JwtService(IConfiguration configuration, IMemoryCache memoryCache, IdWorker idWorker, IHttpContextAccessor httpContent)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
            _idWorker = idWorker;
            this._httpContext = httpContent.HttpContext;
        }

        public string GenerateRefreshToken(string oldToken)
        {
            #region old 
            //string userCacheKey = string.Empty;
            //string flowerId = string.Empty;
            //long data = _idWorker.NextId();
            ////_memoryCache.Remove(userCacheKey);
            //_memoryCache.Set(userCacheKey, data);
            //return data.ToString();
            #endregion
            if (JwtHelper.CheckTokenCanRead(oldToken))
            {
                if (_httpContext != null && _httpContext.User != null && _httpContext.User.Claims != null && _httpContext.User.Claims.Any())
                {
                    _httpContext.Request.Headers.TryGetValue("Authorization", out var bearerToken);
                    if (bearerToken.Count > 0)
                    {
                        string token = bearerToken.First()!;
                        if (JwtHelper.CheckTokenCanRead(token) && _httpContext.User.Identity.IsAuthenticated)
                        {
                            token = token.Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);
                            string? nbf = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "nbf")?.Value;
                            string? exp = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "exp")?.Value;
                            string? iss = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "iss")?.Value;
                            string? aud = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "aud")?.Value;
                            string? clientId = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "client_id")?.Value;
                            string? sub = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "sub")?.Value;
                            string? authTime = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "auth_time")?.Value;
                            string? idp = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "idp")?.Value;
                            string? tenantid = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "tenantid")?.Value;
                            string? tenantFilter = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "__tenantFilter")?.Value;
                            string? factoryId = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "__FactoryId")?.Value;
                            string? factoryCode = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "__FactoryCode")?.Value;
                            string? ecological = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "__Ecological")?.Value;
                            string? userDataOrgId = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "__UserDataOrgId")?.Value;
                            List<string>? roles = _httpContext.User.Claims.Where(item => item.Type == "role").Select(it => it.Value).ToList();
                            string? name = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "name")?.Value;
                            string? email = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "email")?.Value;
                            string? emailVerified = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "email_verified")?.Value;
                            string? phoneNumber = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "phone_number")?.Value;
                            string? phoneNumberVerified = _httpContext.User.Claims.FirstOrDefault(item => item.Type == "phone_number_verified")?.Value;
                            List<string>? scope = _httpContext.User.Claims.Where(item => item.Type == "scope").Select(it => it.Value).ToList();
                            List<string>? amr = _httpContext.User.Claims.Where(item => item.Type == "amr").Select(it => it.Value).ToList();
                            string? userName = _httpContext.Items.FirstOrDefault(it => it.Key.ToString() == "userName").Value?.ToString();
                        }
                    }
                }
            }
            return "token is unvalid";
        }

        public ResponseToken GetJwtToken(string username, int accountId)
        {
            //生成一个刷新令牌

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, accountId.ToString()),
                new Claim("FuckTish","OK"),
                new Claim("FactoryId","15"),
            };


            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretToken));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: cred);

            var jwttoken = new JwtSecurityTokenHandler().WriteToken(token);

            return new ResponseToken()
            {
                Id = accountId,
                Username = username,
                JwtToken = jwttoken,
                ExpireTime = DateTime.Now.AddDays(1),
                RefreshToken = jwttoken,
            };
        }
        public List<Claim>? ValidateJwtToken(string token)
        {
            if (token == null)
                return null;

            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretToken);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return jwtToken.Claims.ToList();
                //var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // return user id from JWT token if validation successful
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }


        public string GenerateRefreshTokenNew(string oldToken)
        {
            var token = oldToken.Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);
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
                    return newToken;
                }
            }
            return "刷新token失败";
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
