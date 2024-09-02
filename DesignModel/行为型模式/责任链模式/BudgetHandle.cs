using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.责任链模式
{
    //责任链模式是一个相对比较简单的模式，它的名字已经非常好的暗示了其工作原理。每个处理器互相首尾连接在一起成为一条链，然后任务顺着这条链往下传，直到被某个处理器处理掉。
    public interface BudgetHandle
    {
        void SetNextHandle(BudgetHandle budgetHandle);
        bool Handler(int amount);
    }
}
