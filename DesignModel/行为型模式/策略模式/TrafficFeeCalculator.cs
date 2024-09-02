using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.策略模式
{
    public class TrafficFeeCalculator
    {
        public int goToTianJinEye(ICalculateStrategy strategy, int distance)
        {
            return strategy.calculateTrafficFee(distance);
        }

        public void TestMain()
        {
            TrafficFeeCalculator calculator = new TrafficFeeCalculator();
            Console.WriteLine($"乘坐公交车到天津之眼的花费为：{calculator.goToTianJinEye(new ByBus(), 10)}块人民币");
            Console.WriteLine($"乘坐公交车到天津之眼的花费为：{calculator.goToTianJinEye(new ByDiDiExpress(), 10)}块人民币");
            Console.WriteLine($"乘坐公交车到天津之眼的花费为：{calculator.goToTianJinEye(new BySharedBicycle(), 10)}块人民币");
        }
    }
}
