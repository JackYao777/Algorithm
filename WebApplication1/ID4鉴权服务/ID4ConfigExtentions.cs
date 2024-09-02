using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Snowflake.Core;
using System.Text;
using WebApplication1.JWT鉴权服务.Context;
using WebApplication1.JWT鉴权服务.IServices;
using WebApplication1.JWT鉴权服务.Services;
using WebApplication1.ID4鉴权服务.Dto;
using WebApplication1.ID4鉴权服务.Profile;

namespace WebApplication1.ID4鉴权服务
{
    //这里要引用包:IdentityServer4,IdentityServer4.AccessTokenValidation
    public static class ID4ConfigExtentions
    {

        public static AuthenticationBuilder AddID4Authcations(this WebApplicationBuilder builder)
        {
            #region 注入所需服务以及数据库,缓存,以及雪花Id
            // 使用内存存储，密钥，客户端和资源来配置身份服务器。
            builder.Services.AddIdentityServer()
                 .AddDeveloperSigningCredential()//开发模式生成token
                 .AddInMemoryApiScopes(ID4Config.ApiScopes)//配置作用域集合
                .AddInMemoryApiResources(ID4Config.GetOneApiResources())
                .AddInMemoryClients(ID4Config.Clients)
                .AddTestUsers(ID4Config.GetTestUsers())
                .AddInMemoryIdentityResources(ID4Config.GetIdentityResources())/*.AddProfileService<CustomerProfileService>()*/;
            #endregion

            #region 注入鉴权服务
            return builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                   .AddIdentityServerAuthentication(option =>
                                   {
                                       option.Authority = "http://localhost:8099";
                                       option.RequireHttpsMetadata = false;
                                       option.ApiName = "TwoApiResources";
                                       //option.ClaimsIssuer = "client";
                                       //option.ApiName = "api1";
                                       //option.ApiSecret = "secret";
                                       //option.ApiName = "api1";
                                       //option.Authority = "http://localhost:5000";// token一般是非对称加密的形式，所以这个配置的是我们服务端获取公钥的地址 用以解密
                                       //option.ApiName = "OneApiResources";     // 这个就是我们在搭建服务端的时候 授权范围的名称， 必须与其一致，要不然就会导致鉴权失败。
                                       //option.RequireHttpsMetadata = false;    // htpps就设置为true

                                   });

            #endregion 
        }
    }
}