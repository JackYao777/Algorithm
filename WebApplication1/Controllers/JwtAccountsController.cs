using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Claims;
using WebApplication1.JWT鉴权服务.Dtos;
using WebApplication1.JWT鉴权服务.IServices;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// JWT模拟权限控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class JwtAccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;
        private readonly IJwtService _jwtService;


        public JwtAccountsController(IAccountsService accountsService, IJwtService jwtService)
        {
            _accountsService = accountsService;
            _jwtService = jwtService;
        }

        private static readonly string[] Summaries = new[]
       {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        [HttpPost("SignUp")]
        public ActionResult Signup(AuthRequestDto request)
        {
            _accountsService.SignupNewAccount(request.UserName, request.Password);
            return Ok();
        }

        /// <summary>
        /// 登录获取token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public ActionResult Login(AuthRequestDto request)
        {
            var (loginSuccess, account) = _accountsService.Login(request.UserName, request.Password);

            if (!loginSuccess)
            {
                return BadRequest("Invalid username or password");
            }
            else
            {
                var jwt = _jwtService.GetJwtToken(account.Username, account.Id);
                return Ok(jwt);
            }
        }

        /// <summary>
        /// 根据token获取数据
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet(nameof(GetDataByToken))]
        public IEnumerable<WeatherForecast> GetDataByToken()
        {
            var userIdStr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userIdInt = int.Parse(userIdStr);

            Log.Information($"User {userIdInt} is trying to get weather forecast");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Authorize]
        [HttpGet(nameof(GenerateRefreshToken))]
        public string GenerateRefreshToken(string token)
        {
            return _jwtService.GenerateRefreshTokenNew(token);
        }

        [HttpGet(nameof(ValidataToken))]
        public List<Claim> ValidataToken(string token)
        {
            return _jwtService.ValidateJwtToken(token);
        }
    }
}
