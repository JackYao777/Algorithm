using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.状态模式
{
    public class StateClient
    {
        public void buyKeyboard()
        {
            //状态的保持与切换者
            JdLogistics jdLogistics = new JdLogistics();

            //接单状态
            OrderState orderState = new OrderState();
            jdLogistics.SetLogisticsState(orderState);
            jdLogistics.doAction();

            //出库状态
            ProductOutState productOutState = new ProductOutState();
            jdLogistics.SetLogisticsState(productOutState);
            jdLogistics.doAction();

            //运输状态
            //TransportState transportState = new TransportState();
            //jdLogistics.setLogisticsState(transportState);
            //jdLogistics.doAction();
        }
    }
}
