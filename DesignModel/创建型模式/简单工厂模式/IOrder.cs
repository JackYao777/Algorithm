using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.简单工厂模式
{
    public interface IOrder
    {
        /// <summary>
        /// 下单
        /// </summary>
        /// <returns></returns>
        bool CreateOrder();
        /// <summary>
        /// 获取标签
        /// </summary>
        /// <returns></returns>
        bool PrintLable();
    }
}
