using DesignModel.创建型模式.简单工厂模式;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.抽象工厂模式
{
    public abstract class AbstractFactory
    {
        public abstract IOrder GetOrderService(string color);//订单产品组
        public abstract ISharp getShape(string shape);//形状产品组
    }
}
