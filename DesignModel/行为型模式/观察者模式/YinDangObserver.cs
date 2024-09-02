using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.观察者模式
{
    public class YinDangObserver : ITianDogObserver
    {
        public void Update(string message)
        {
            if (message == "肚子好饿")
            {
                Console.WriteLine("二狗：半夜起来，翻墙出去步行2公里买女神最爱吃的小笼包... 上官：二狗，你真是个好人");
            }
            else if (message == "心情不好")
            {
                Console.WriteLine("二狗：官哭着述说渣男怎么欺负的她...整整3个小时，全程安慰... 上官：二狗，你真是个好人");
            }
            else
            {
                Console.WriteLine("随叫随到...");
            }
        }
    }
}
