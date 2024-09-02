using WebApplication1.JWT鉴权服务.Dtos;

namespace WebApplication1.JWT鉴权服务.IServices
{
    public interface IAccountsService
    {
        Account SignupNewAccount(string username, string password);
        (bool, Account) Login(string username, string password);
    }
}
