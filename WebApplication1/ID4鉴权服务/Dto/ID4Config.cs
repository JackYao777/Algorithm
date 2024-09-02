using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using IdentityServer4;

namespace WebApplication1.ID4鉴权服务.Dto
{
    public static class ID4Config
    {
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
            //new ApiScope("api1", "My API")
              new ApiScope("ScopeOne"),
              new ApiScope("ScopeTwo"),
              //new ApiScope("openid"),
              //new ApiScope("address"),
              //new ApiScope("profile"),
              //new ApiScope("email"),
        };

        //获取授权范围
        public static List<ApiResource> GetOneApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("OneApiResources","描述")  //  请大家一定要重点关注这个 授权范围，一定要记住这个名字，因为后面客户端有一个apiName 两者需要一致
                {
                    Scopes={ "ScopeOne"}
                },
                new ApiResource("TwoApiResources","描述2",new List<string>(){JwtClaimTypes.Address,JwtClaimTypes.Email,JwtClaimTypes.Name,"TELLPHone"})//这里可以显示用户的额外信息
                {
                    Scopes={"ScopeTwo"}

                },

            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                //new IdentityResources.OpenId(),
                //new IdentityResources.Email(),
                //new IdentityResources.Address(),
                //new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> Clients => new List<Client>
        {
             new Client()
             {
                ClientId = "client",
                //ClientName="jack",
                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                
                // secret for authentication
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                // scopes that client has access to
                AllowedScopes = { "ScopeOne", "ScopeTwo" }
             },

             new Client(){
                    ClientId="webClient",  //客户端ID 全场唯一的
                    ClientName="网页端",   // 客户端名称
                    ClientSecrets =
                    {
                        new Secret("baishikele".Sha256()),  //这是客户端的密码 允许多个
                        new Secret("baishikele123".Sha256())
                    },
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,  //这个是模式，有密码模式 客户端模式 客户端和密码模式, 我们这里采用的是客户端模式.
                                                                     //客户端模式 是针对的任意客户端,不管你是移动端,还是PC端,亦或是各种乱七八糟的端.
                                                                     //用户模式 是针对的用户本身.也就是系统的用户好吧.
                    RedirectUris = { "http://localhost:5000/signin-oidc" },
                    AllowedScopes={ IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.Address,"ScopeOne", "ScopeTwo" },// 这个是作用域
                     
                    // 这里是token生成后 token解析后的第二段公开的数据
                    //Claims =
                    //{
                    //    new ClientClaim("name","杨朋"),
                    //    new ClientClaim("email","1430633118@qq.com"),
                    //    new ClientClaim("age","28"),
                    //    new ClientClaim("gy","直线谁不会加速啊? 弯道快才是真的快！"),
                    //    new ClientClaim(JwtClaimTypes.Name,"杨朋JWT")

                    //},
                    AlwaysSendClientClaims=true,
                    AlwaysIncludeUserClaimsInIdToken=true
                }
       };


        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>() {
                new TestUser() {
                    Username="张三",
                    Password="123456",
                    IsActive=true,
                    SubjectId="1",
                    ProviderSubjectId="1",
                    Claims=new List<System.Security.Claims.Claim>() {
                     new System.Security.Claims.Claim(JwtClaimTypes.Name,"杨朋"),
                     new System.Security.Claims.Claim(JwtClaimTypes.Email,"1430633118@qq.com"),
                     new System.Security.Claims.Claim(JwtClaimTypes.Address,"北京是恶河源"),
                     new System.Security.Claims.Claim(JwtClaimTypes.FamilyName,"直线谁不会加速啊? 弯道快才是真的快！"),
                     new System.Security.Claims.Claim("TELLPHone","1008611")
                    },
                }
            };
        }
    }
}
