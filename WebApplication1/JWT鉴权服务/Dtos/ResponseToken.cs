using System.Text.Json.Serialization;

namespace WebApplication1.JWT鉴权服务.Dtos
{
    public class ResponseToken
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string JwtToken { get; set; }

        /// <summary>
        /// 刷新Token
        /// </summary>
        // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireTime { get; set; }
    }
}
