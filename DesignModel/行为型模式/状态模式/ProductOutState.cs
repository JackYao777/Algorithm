using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.状态模式
{
    public class ProductOutState : ILogisticsState
    {
        public void DoAction(JdLogistics logistics)
        {
            Console.WriteLine("商品已经出库...");
            logistics.doAction();
        }
    }
}
