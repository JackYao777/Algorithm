using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.桥接模式
{
    public class LargeCoffeeByMike : AbstrctCoffee
    {
        public LargeCoffeeByMike(ICoffeeAddition coffeeAddition) : base(coffeeAddition)
        {

        }

        public override void Coffee()
        {
            //coffeeAddition.AddSometing();
            base.Coffee();
            Console.WriteLine("大杯做法");
        }
    }
}
