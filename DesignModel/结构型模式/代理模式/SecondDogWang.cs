using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式
{
    public class SecondDogWang : ILawSuit
    {
        public void Defend()
        {
            Console.WriteLine($"铁证如山,老板还钱");
        }

        public void Submit(string proof)
        {
            Console.WriteLine($"老板欠薪跑路，证据如下{proof}");
        }
    }
}
