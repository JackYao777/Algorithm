using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignModel.行为型模式.状态模式
{
    /// <summary>
    /// 上下文里面还引用物流状态接口
    /// </summary>
    public class JdLogistics
    {
        private ILogisticsState logisticsState;

        public void SetLogisticsState(ILogisticsState logisticsState)
        {
            this.logisticsState = logisticsState;
        }

        public ILogisticsState getLogisticsState()
        {
            return logisticsState;
        }

        public void doAction()
        {
            logisticsState.DoAction(this);
        }
    }
}
