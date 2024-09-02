using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.责任链模式
{
    public class Manager : BudgetHandle
    {
        private BudgetHandle nextHandler;

        public void SetNextHandle(BudgetHandle budgetHandle)
        {
            this.nextHandler = nextHandler;
        }

        public bool Handler(int amount)
        {
            if (amount < 5000)
            {
                Console.WriteLine("小钱，批了！");
                return true;
            }
            Console.WriteLine("超出GroupLeader权限,请更高级管理层批复");
            return nextHandler.Handler(amount);
        }
    }
}
