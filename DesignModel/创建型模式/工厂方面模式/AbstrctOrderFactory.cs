using DesignModel.创建型模式.简单工厂模式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.工厂方面模式
{
    public interface AbstrctOrderFactory
    {
        IOrder CreateOrderFactory();//同一个产品组,如果不是一个产品族的话
    }
}
