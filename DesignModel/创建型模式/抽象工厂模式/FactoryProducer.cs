using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.抽象工厂模式
{
    public class FactoryProducer
    {
        public static AbstractFactory getFactory(string choice)
        {
            if (choice == "SHAPE")
            {
                return new SharpFactoryNew();
            }
            else if (choice == "OrderService")
            {
                return new OrderServiceFactoryNew();
            }
            return null;
        }
    }
}
