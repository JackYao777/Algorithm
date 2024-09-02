using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.装饰者模式
{
    public class OriginalCoffee : ICoffee
    {
        public void MarkCoffee()
        {
            Console.WriteLine("原味咖啡");
        }
    }
}
