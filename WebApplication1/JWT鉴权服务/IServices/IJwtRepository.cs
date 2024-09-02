using System.Security.Principal;
using WebApplication1.JWT鉴权服务.Dtos;

namespace WebApplication1.JWT鉴权服务.IServices
{
    public interface IJwtRepository
    {
        void SaveAccount(Account account);
        Account GetAccount(string username);
    }
}
