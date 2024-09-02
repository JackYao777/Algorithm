using DesignModel.创建型模式.工厂方面模式;
using DesignModel.创建型模式.抽象工厂模式;
using DesignModel.创建型模式.简单工厂模式;
using DesignModel.结构型模式.享元模式;
using DesignModel.结构型模式.代理模式;
using DesignModel.结构型模式.代理模式.动态代理;
using DesignModel.结构型模式.组合模式;
using DesignModel.结构型模式.装饰者模式;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;

namespace DesignModel
{
    internal class Program
    {
        //设计模式的六种原则:单一原则,依赖倒置原则,开放-关闭原则,迪米特原则,接口隔离原则,里氏替换原则
        static void Main(string[] args)
        {
            #region 数据模拟
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            //list.Remove(1);
           int indexId= list.IndexOf(2);
            foreach (int item in list)
            {
               list.Remove(item);
                Console.WriteLine(item);
            }

            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i] = 5;
            //    list.Remove(list[i]);
            //}
            #endregion

            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("sdfsdf");
            //stringBuilder.ToString();
            //IApplicationBuilder
            //RequestDelegate
            #region 模拟数据
            //简单工厂模式, 好处:统一创建类进行管理,坏处:每加个服务商类,就要改动工厂类代码(不符合开闭原则)
            //IOrder orderService = OrdrFactory.CreateOrderService("FS");
            //orderService.CreateOrder();
            //orderService.PrintLable();

            ////工厂方法模式  好处：符合开闭原则, 坏处：每增加一个产品就要增加一个具体产品类和一个对应的具体工厂类，这增加了系统的复杂度。
            ////一个抽象产品类，可以派生出多个具体产品类。IOrder
            ////一个抽象工厂类，可以派生出多个具体工厂类。AbstrctOrderFactory
            ////每个具体工厂类只能创建一个具体产品类的实例。
            //AbstrctOrderFactory abstrctOrderFactory = new FSOrderServiceFactory();
            //abstrctOrderFactory.CreateOrderFactory();

            //AbstractFactory abstractFactory = FactoryProducer.getFactory("cilgle");
            //abstractFactory.GetOrderService("cilgle");

            //IHostBuilder builder = Host.CreateDefaultBuilder(args);
            #endregion

            #region 组合模式
            //CompositeClient composite = new CompositeClient();
            //composite.listOrgInfo();
            #endregion

            #region 装饰者模式
            //原味咖啡
            //ICoffee coffee = new OriginalCoffee();
            //coffee.MarkCoffee();
            //Console.WriteLine();

            ////加奶的咖啡
            //coffee = new MilkDecorator(coffee);
            //coffee.MarkCoffee();

            ////先加奶后加糖的咖啡
            //coffee = new SugarDecorator(coffee);
            //coffee.MarkCoffee();
            #endregion

            #region 享元模式
            //FlyweightClient flyweightClient = new FlyweightClient();
            //flyweightClient.playChess();
            #endregion

            #region 静态数据
            //ProxyFactory.GetProxy().Submit("工资流水在此");
            //ProxyFactory.GetProxy().Defend();

            #endregion

            #region
            ILawSuit proxy = (ILawSuit)ProxyFactory.GetProxy(new CuiHuaNiu());
            proxy.Submit("工资流水在此");
            proxy.Defend();
            #endregion
        }
    }
}