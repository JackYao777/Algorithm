using Castle.DynamicProxy;

namespace WebApplication1.动态代理.Interceptor
{
    public class SomeInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            //Do before... 在这之前做业务逻辑
            Console.WriteLine("这里处理业务之前做业务逻辑");
            try
            {
                invocation.Proceed();
            }
            catch
            {

            }
            Console.WriteLine("这里处理业务之后做业务逻辑");
            //Do after...  在这之后做业务逻辑
        }
    }
}
