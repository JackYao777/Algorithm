using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Query;
using WebApplication1.IOC容器.Dto;

namespace WebApplication1.IOC容器.IServices
{
    /// <summary>
    /// 抽象出容器方法
    /// </summary>
    public interface IJackIOCContainer
    {
        /// <summary>
        /// 注入方法
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="shortName">类名称</param>
        /// <param name="paraList"></param>
        void Register<TFrom, TTo>(string shortName = null, object[] paraList = null, LifetimeType lifetimeType=LifetimeType.Transient) where TTo : TFrom;


        TFrom Resolve<TFrom>(string shortName);

        IJackIOCContainer CreateChildContainer();
        // 容器的作用,注入，和创建对象,返回一个Containner,实现它的实例也必须要继承这两个接口,然后用什么存储就是细节问题了，
    }
}
