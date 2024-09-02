using DesignModel.结构型模式.代理模式.动态代理;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DesignModel.结构型模式.代理模式
{
    /// <summary>
    /// 可以看到，代理律师全权代理了王二狗的本次诉讼活动。那使用这种代理模式有什么好处呢，我们为什么不直接让王二狗直接完成本次诉讼呢？现实中的情况比较复杂，但是我可以简单列出几条：这样代理律师就可以在提起诉讼等操作之前做一些校验工作，或者记录工作。例如二狗提供的资料，律师可以选择的移交给法庭而不是全部等等操作，就是说可以对代理的对做一些控制。例如二狗不能出席法庭，代理律师可以代为出席。。。
    /// </summary>
    public class ProxyFactory
    {
        public static Object GetProxy(Object target)
        {
            //return new ProxyLawyer(new SecondDogWang());
            IInvocationHandler handler = new AnyOneProxy(target);
            var mm = DynamicProxy.CreateProxyByInterface<ILawSuit>(handler, false);
            return mm;
        }
    }
}
