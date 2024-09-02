using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.适配器模式
{
    public class HuaWeiSocket : IHuaWSocket
    {
        public void Charge()
        {
            Console.WriteLine("华为转接头");
        }
    }
}
