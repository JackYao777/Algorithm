using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.装饰者模式
{
    public abstract class CoffeeDecorator : ICoffee
    {
        private readonly ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual void MarkCoffee()
        {
            if (_coffee is not null)
            {
                _coffee.MarkCoffee();
            }
        }
    }
}
