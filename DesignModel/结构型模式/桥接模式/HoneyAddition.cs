using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.桥接模式
{
    public class HoneyAddition : ICoffeeAddition
    {
        public void AddSometing()
        {
            Console.WriteLine("添加蜂蜜");
        }
    }
}
