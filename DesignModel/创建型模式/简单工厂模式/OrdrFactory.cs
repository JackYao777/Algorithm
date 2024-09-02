using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.简单工厂模式
{
    public class OrdrFactory
    {
        public static IOrder CreateOrderService(string orderName)
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
    }
}
