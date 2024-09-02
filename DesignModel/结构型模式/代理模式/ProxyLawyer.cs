using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式
{
    public class ProxyLawyer : ILawSuit
    {
        public ILawSuit plainiff;//持有要代理的那个对象

        public ProxyLawyer(ILawSuit plainiff)
        {
            this.plainiff = plainiff;
        }

        public void Defend()
        {
            //这里面是不是律师可以做一些其他的东西
            plainiff.Defend();
            //这里面是不是律师可以做一些其他的东西
        }

        public void Submit(string proof)
        {
            //这里面是不是律师可以做一些其他的东西
            plainiff.Submit(proof);
            //这里面是不是律师可以做一些其他的东西
        }
    }
}
