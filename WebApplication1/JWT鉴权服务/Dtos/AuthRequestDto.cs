namespace WebApplication1.JWT鉴权服务.Dtos
{
    public class AuthRequestDto
    {

        /// <summary>
        /// 姓名
        /// </summary>
        /// <example>李四</example>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <example>123456</example>
        public string Password { get; set; }
    }
}
