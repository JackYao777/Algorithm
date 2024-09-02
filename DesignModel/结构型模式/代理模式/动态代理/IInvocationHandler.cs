using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式.动态代理
{
    /// <summary>
    /// 对应java的InvocationHandler接口
    /// 使用上应该是差不多的
    /// 注意点是，因为C#的Property的getset也是走这一个方法的
    /// 对于接口来说是全部代理，但是对于类只有虚方法代理
    /// </summary>
    public interface IInvocationHandler
    {
        public object Invoke(object proxy, MethodInfo method, object[] args);
    }

    /// <summary>
    /// 缓存类，可以无视
    /// </summary>
    public class ProxyTypeInfo
    {
        public TypeBuilder TypeBuilder;
        public int Count;
        public MethodInfo[] MethodInfos;
    }


}
