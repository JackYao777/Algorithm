using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ID4鉴权服务.Dto;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Identity4鉴权控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]

    public class ID4Controller : ControllerBase
    {
        public ID4Controller()
        {

        }
        /// <summary>
        /// 权限测试方法
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet(nameof(GetUserClaimsDatas))]
        public async Task<IActionResult> GetUserClaimsDatas()
        {
            var claims = User.Claims.Select(x => new { x.Type, x.Value });
            return await Task.FromResult(Ok(claims));
        }

        /// <summary>
        /// 获取Token方法,根据密码模式
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetID4TokenByPasswordToken))]
        public async Task<string> GetID4TokenByPasswordToken([FromQuery] UserDto userDto)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:8099");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return "获取token失败";
            }

            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //{
            //    Address = disco.TokenEndpoint,

            //    ClientId = "webClient",
            //    ClientSecret = "baishikele",
            //    Scope = "ScopeOne",
            //    //GrantType = OidcConstants.GrantTypes.ClientCredentials
            //}); ;

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = "webClient",
                //UserName= "网页端",
                //Password= "123456",
                ClientSecret = "baishikele",
                Scope = "ScopeTwo",
                Password = userDto.PassWord,
                UserName = userDto.Name,
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return "";
            }
            return tokenResponse.AccessToken;
        }

        /// <summary>
        /// 获取Token方法,根据客户端模式
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetID4TokenByClinetId))]
        public async Task<string> GetID4TokenByClinetId()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:8099");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return "获取失败";
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "ScopeTwo",
            });
            return tokenResponse.AccessToken;
        }
    }
}
