using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.动态代理.IServces;

namespace WebApplication1.动态代理.Services
{
    public class SomeImpClass : ImpClass
    {
        public virtual void GetCenterData()
        {
            Console.WriteLine("这里是获取中心数据业务逻辑");
        }
    }
    //public class QJExpetion:IExceptionFilter
}
