using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.简单工厂模式
{
    public class YTOrderService : IOrder
    {
        public bool CreateOrder()
        {
            //调用圆通接口
            return true;
        }

        public bool PrintLable()
        {
            //调用圆通接口
            return true;
        }
    }
}
