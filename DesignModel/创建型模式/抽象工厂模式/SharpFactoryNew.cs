using DesignModel.创建型模式.简单工厂模式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.抽象工厂模式
{
    public class SharpFactoryNew : AbstractFactory
    {
        public override IOrder GetOrderService(string color)
        {
            throw new NotImplementedException();
        }

        public override ISharp getShape(string shapeName)
        {
            switch (shapeName)
            {
                case "SanJiao":
                    return new SanJiao();
                case "Yuan":
                    return new Yuan();
                default:
                    return new SanJiao();
            }
        }
    }
}
