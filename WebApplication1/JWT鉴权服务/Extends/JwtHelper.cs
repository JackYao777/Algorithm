using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1.JWT鉴权服务.Extends
{
    public class JwtHelper
    {
        /// <summary>
        /// Toekn是否可以解析
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool CheckTokenCanRead(string token)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            token = token.Replace("Bearer ", "", StringComparison.InvariantCultureIgnoreCase);
            bool isCanRead = jwtHandler.CanReadToken(token);
            return isCanRead;
        }
    }
}
