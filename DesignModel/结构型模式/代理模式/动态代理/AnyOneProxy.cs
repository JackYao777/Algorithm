using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式.动态代理
{
    /// <summary>
    /// 这个才是正在的态代理类  https://blog.csdn.net/q932104843/article/details/90677245
    /// </summary>
    public class AnyOneProxy : IInvocationHandler
    {
        private Object target;//被代理的对象
        public AnyOneProxy(Object obj)
        {
            this.target = obj;
        }

        public object Invoke(object proxy, MethodInfo method, object[] args)
        {
            AfterProcess();//处理其他业务逻辑

            //代理的前后都可以加上业务逻辑after    (这里就是通过动态代理实现了Aop的功能)
            //Console.WriteLine("案件进展：" + method.Name);
            Object result = method.Invoke(target, args);

            AfterProcess();//之后处理业务逻辑
            //before
            return result;
        }

        public virtual void AfterProcess() { }


        public virtual void BeforeProcess() { }

    }
}
