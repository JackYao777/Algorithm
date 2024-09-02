using Castle.DynamicProxy;
using WebApplication1.动态代理.Interceptor;
using WebApplication1.动态代理.IServces;

namespace WebApplication1.动态代理.Services
{

    //包引用nuget:
    //Castle.Core
    public class DynamicService
    {
        public void TestDynamicService()
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();
            //ImpClass proxyClass = proxyGenerator.CreateClassProxy<SomeImpClass>(new SomeInterceptor());
            ImpClass proxyClass2 = (ImpClass)proxyGenerator.CreateClassProxy(typeof(SomeImpClass), new SomeInterceptor());
            proxyClass2.GetCenterData();
        }
    }
}
