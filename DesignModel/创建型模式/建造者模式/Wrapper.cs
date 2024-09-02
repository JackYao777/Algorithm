using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.建造者模式
{
    public class Wrapper : IPacking
    {
        public string Pack()
        {
            return "Wrapper方式";
        }
    }
}
