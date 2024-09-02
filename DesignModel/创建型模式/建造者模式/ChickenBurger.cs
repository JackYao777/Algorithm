using DesignModel.创建型模式.建造者模式;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.建造者模式
{
    public class ChickenBurger : Burger
    {
        public override string Name()
        {
            return "ChickenBurger";
        }

        public override float Price()
        {
            return 50.5f;
        }
    }
}
