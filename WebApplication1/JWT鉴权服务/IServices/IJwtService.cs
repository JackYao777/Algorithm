using System.Security.Claims;
using WebApplication1.JWT鉴权服务.Dtos;

namespace WebApplication1.JWT鉴权服务.IServices
{
    public interface IJwtService
    {
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="accountId">用户Id</param>
        /// <returns></returns>
        ResponseToken GetJwtToken(string username, int accountId);

        /// <summary>
        /// 验证token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
         List<Claim>? ValidateJwtToken(string token);

        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="oldToken"></param>
        /// <returns></returns>
        string GenerateRefreshToken(string oldToken);

        /// <summary>
        /// token刷新
        /// </summary>
        /// <param name="oldToken"></param>
        /// <returns></returns>
        string GenerateRefreshTokenNew(string oldToken);
    }
}
