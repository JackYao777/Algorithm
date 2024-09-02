using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式.动态代理
{
    public class CuiHuaNiu : ILawSuit
    {
        public void Defend()
        {
            Console.WriteLine("铁证如山，还牛翠花血汗钱，马旭");
        }

        public void Submit(string proof)
        {
            Console.WriteLine("翠花提交证据" + proof);
        }
    }
}
