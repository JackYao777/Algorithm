using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.装饰者模式
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {

        }
        public override void MarkCoffee()
        {
            base.MarkCoffee();
            AddMilk();
        }

        private void AddMilk()
        {
            Console.WriteLine("添加一些牛奶");
        }
    }
}
