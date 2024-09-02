using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.装饰者模式
{
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee)
        {
        }
        public override void MarkCoffee()
        {
            base.MarkCoffee();
            AddSugar();
        }

        private void AddSugar()
        {
            Console.WriteLine("添加糖");
        }
    }
}
