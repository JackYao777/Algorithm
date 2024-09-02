using IdentityModel;
using IdentityServer4.Validation;
using System.Security.Claims;

namespace WebApplication1.ID4鉴权服务.Profile
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (!string.IsNullOrEmpty(context.UserName) && !string.IsNullOrEmpty(context.Password))
            {
                //var loginUser = UserService.Users.First(c => c.Username == context.UserName && c.Password == context.Password);

                //if (loginUser != null)
                //{
                context.Result = new GrantValidationResult("1", OidcConstants.AuthenticationMethods.Password, new Claim[] { new Claim("my_phone", "10086"), new Claim("jack", "sdafdsaf") }); //这里增加自定义信息
                return Task.CompletedTask;
                //}
            }
            return Task.CompletedTask;
        }
    }
}
