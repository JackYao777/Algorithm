using DesignModel.创建型模式.简单工厂模式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.抽象工厂模式
{
    //如果这么写就不符合开闭原则了（对扩展开放,对修改封闭,怎么才能符合要求，那就是多建几个工场内）
    public class OrderServiceFactoryNew : AbstractFactory
    {
        public override IOrder GetOrderService(string orderName)
        {
            switch (orderName)
            {
                case "FS":
                    return new SFOrderService();
                case "YT":
                    return new YTOrderService();
                default:
                    return new SFOrderService();
            }
        }

        public override ISharp getShape(string shape)
        {
            throw new NotImplementedException();
        }
    }
}
