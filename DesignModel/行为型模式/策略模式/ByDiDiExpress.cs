using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.策略模式
{
    public class ByDiDiExpress : ICalculateStrategy
    {
        public int calculateTrafficFee(int distance)
        {
            return distance < 3 ? 8 : (8 + (distance - 3) * 3);
        }
    }
}
