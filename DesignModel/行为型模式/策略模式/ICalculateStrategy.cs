using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.策略模式
{
    public interface ICalculateStrategy
    {
        int calculateTrafficFee(int distance);
    }
}
