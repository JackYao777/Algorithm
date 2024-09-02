using WebApplication1.JWT鉴权服务.Context;
using WebApplication1.JWT鉴权服务.Dtos;
using WebApplication1.JWT鉴权服务.IServices;

namespace WebApplication1.JWT鉴权服务.Services
{
    public class JwtRepository : IJwtRepository
    {
        private readonly JwtDemoDbContext _context;
        public JwtRepository(JwtDemoDbContext context)
        {
            _context = context;
        }

        public Account GetAccount(string username)
        {
            return _context.Accounts.FirstOrDefault(a => a.Username == username);
        }

        public void SaveAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
