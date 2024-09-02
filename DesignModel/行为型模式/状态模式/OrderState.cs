using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.状态模式
{
    public class OrderState : ILogisticsState
    {
        public void DoAction(JdLogistics logistics)
        {
            logistics.doAction();
            Console.WriteLine("商家已经接单，正在处理中...");
        }
    }
}
