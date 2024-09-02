using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Text;
using WebApplication1.全局日志.Dtos;

namespace WebApplication1.全局日志.filters
{
    public class AbpAsyncExceptionFilter : IAsyncExceptionFilter
    {

        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<AbpAsyncExceptionFilter> _logger;

        /// <summary>
        /// Http请求对象工厂
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// 服务提供者
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="httpClientFactory">请求对象</param>
        /// <param name="logger">日志</param>
        /// <param name="serviceProvider">服务提供者</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AbpAsyncExceptionFilter(IHttpClientFactory httpClientFactory, ILogger<AbpAsyncExceptionFilter> logger, IServiceProvider serviceProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            Exception exception = context.Exception;
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var result = new AbpExceptionResult()
                {
                    Error = new Error()
                    {
                        Code = "1004",
                        Message = exception.Message,
                        Details = "业务异常"
                    }
                };
                context.Result = new JsonResult(result);
            }
            if (context.Exception.GetType() == typeof(ArgumentNullException)
                || context.Exception.GetType() == typeof(ArgumentException))

            {

                var result = new AbpExceptionResult()
                {
                    Error = new Error()
                    {
                        Code = "1005",
                        Message = exception.Message,
                        Details = "业务参数异常"
                    }
                };
                context.Result = new JsonResult(result);
            }
            else
            {

                var result = new AbpExceptionResult()
                {
                    Error = new Error()
                    {
                        Code = "1006",
                        Message = exception.Message,
                        Details = "内部异常"
                    }
                };
                context.Result = new JsonResult(result);
            }
            StringBuilder msg = new StringBuilder();
            msg.AppendLine(exception.Message);
            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"{exception.StackTrace}");
            sql.AppendLine($"{exception.Message}");
            _logger.LogError(sql.ToString());
            Log.Information(sql.ToString());
            context.ExceptionHandled = true;
            await Task.CompletedTask;
        }
    }
}
