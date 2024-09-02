using DesignModel.创建型模式.简单工厂模式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.工厂方面模式
{
    public class FSOrderServiceFactory : AbstrctOrderFactory
    {
        public IOrder CreateOrderFactory()
        {
            return new SFOrderService();
        }
    }
}
