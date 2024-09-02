using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignModel.建造者模式;

namespace DesignModel.创建型模式.建造者模式
{
    public abstract class Burger : Item
    {
        public abstract string Name();


        public IPacking Packing()
        {
            return new Wrapper();
        }

        public abstract float Price();

    }
}
