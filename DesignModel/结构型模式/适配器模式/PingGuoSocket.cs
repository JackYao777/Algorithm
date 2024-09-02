using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.适配器模式
{
    public class PingGuoSocket : IPingGuoSocket
    {
        public void PingGuoCharge()
        {
            Console.WriteLine("苹果转接头");
        }
    }
}
