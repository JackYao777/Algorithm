using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.代理模式
{
    public interface ILawSuit
    {
        void Submit(string proof);//提起诉讼
        void Defend();//法庭辩护
    }
}
