using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.责任链模式
{
    public class CFO : BudgetHandle
    {

        private BudgetHandle nextHandler;

        public void SetNextHandle(BudgetHandle budgetHandle)
        {
            this.nextHandler = nextHandler;
        }

        public bool Handler(int amount)
        {
            if (amount < 10000)
            {
                Console.WriteLine("小钱，批了！");
                return true;
            }
            if (nextHandler != null)
            {
                return nextHandler.Handler(amount);
            }
            //已经没有更高级的管理层来处理了
            Console.WriteLine("太多了，回去好好看看能不能缩减一下");
            return false;
        }
    }
}
