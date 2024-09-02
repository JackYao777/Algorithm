using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.责任链模式
{
    public class DogWang2Cor
    {
        public void applyBudget()
        {
            GroupLeader leader = new GroupLeader();
            Manager manager = new Manager();
            CFO cfo = new CFO();

            leader.SetNextHandle(manager);
            manager.SetNextHandle(cfo);

            Console.WriteLine("领导您好：由于开发需求，需要购买一台Mac笔记本电脑，预算为%d 望领导批准", 95000);
            if (leader.Handler(95000))
            {
                Console.WriteLine("谢谢领导");
            }
            else
            {
                Console.WriteLine("巧妇难为无米之炊，只能划船了...");
            }
        }
    }
}
