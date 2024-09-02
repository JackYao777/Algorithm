using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.IOC容器.Dto;
using WebApplication1.IOC容器.IServices;
using WebApplication1.IOC容器.Services;

namespace ZWBasicServer
{

    public class IOCTest
    {
        [Fact]
        public void TestIOC()
        {
            JackIOCContainer container = new JackIOCContainer();
            {
                //注册
                container.Register<ITestServiceA, TestServiceA>(); //将ITestServiceA注册到TestServiceA
                container.Register<ITestServiceB, TestServiceB>();
                container.Register<ITestServiceB, TestServiceB>(shortName: "ServiceB");
                container.Register<ITestServiceC, TestServiceC>();
                container.Register<ITestServiceD, TestServiceD>(paraList: new object[] { "浪子天涯", 666 }, lifetimeType: LifetimeType.Singleton);

                ITestServiceD d1 = container.Resolve<ITestServiceD>(); //创建对象交给IOC容器
                //ITestServiceD d2 = container.Resolve<ITestServiceD>();
                d1.Show();
                //Console.WriteLine($"object.ReferenceEquals(d1, d2) = {object.ReferenceEquals(d1, d2)}");
            }
        }
    }
}
