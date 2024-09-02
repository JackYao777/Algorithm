using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Security.Claims;

namespace WebApplication1.ID4鉴权服务.Profile
{
    public class CustomerProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //自定义传出证件信息
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("PhoneTell", "128739824"));
            claims.Add(new Claim("FacId", "2001"));//这里有问题,导致用户claim出不来
            context.IssuedClaims.AddRange(claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.CompletedTask;
        }
    }
}
