using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.状态模式
{
    /// <summary>
    /// 物流状态接口
    /// </summary>
    public interface ILogisticsState
    {
        /// <summary>
        /// 这里传入上下文
        /// </summary>
        /// <param name="logistics"></param>
        void DoAction(JdLogistics logistics);
    }
}
