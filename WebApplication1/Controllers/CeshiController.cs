using Microsoft.AspNetCore.Mvc;
using WebApplication1.全局日志.Services;
using WebApplication1.动态代理.Services;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 动态代理以及日志测试控制器
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CeshiController : ControllerBase
    {
        //异常服务测试
        private ExceptServiceTest _exceptServiceTest;

        //动态代理实现拦截测试服务
        private DynamicService _dynamicService;

        public CeshiController(ExceptServiceTest exceptServiceTest, DynamicService dynamicService)
        {
            _exceptServiceTest = exceptServiceTest;
            _dynamicService = dynamicService;
        }

        /// <summary>
        /// 测试日志全局报错处理
        /// </summary>
        [HttpGet(nameof(CeshiLogInfomation))]
        public void CeshiLogInfomation()
        {
            _exceptServiceTest.Test();
        }

        /// <summary>
        /// 测试动态代理拦截
        /// </summary>
        [HttpGet(nameof(CeshiDynamicService))]
        public void CeshiDynamicService()
        {
            _dynamicService.TestDynamicService();
        }
    }
}
