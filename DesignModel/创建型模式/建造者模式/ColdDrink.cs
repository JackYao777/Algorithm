using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.建造者模式
{
    public abstract class ColdDrink : Item
    {
        public abstract string Name();

        public IPacking Packing()
        {
            return new Bottle();
        }
        public abstract float Price();

    }
}
