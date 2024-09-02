using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.桥接模式
{
    //容量和口感做了一个桥接
    public abstract class AbstrctCoffee : ICoffee, ICoffeeAddition
    {
        public ICoffeeAddition coffeeAddition;
        public AbstrctCoffee(ICoffeeAddition coffeeAddition)
        {
            this.coffeeAddition = coffeeAddition;
        }
        public virtual void Coffee()
        {
            AddSometing();
        }

        public virtual void AddSometing()
        {
            coffeeAddition.AddSometing();
        }
    }
}
