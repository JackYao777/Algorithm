using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.外观模式
{
    /**
 * @see 告诉厨师，将屏蔽底层实现，厨师知道买什么菜，怎么做饭。
 * @author Thornhill
 *
 */
    public class Chef
    {
        public void cooking(String foodName)
        {
            List<String> names = new List<string>();
            switch (foodName)
            {
                case "西红柿鸡蛋":
                    names.Add("鸡蛋");
                    names.Add("西红柿");

                    break;
                case "京酱肉丝":
                    names.Add("肉");
                    names.Add("葱");
                    break;
                default:
                    Console.WriteLine("您的厨师暂时不支持此功能"); 
                    return;
                    // break;
            }
            Groceries groceries = new Groceries(names);
            // 完成购买
            groceries.buy();

            Clean clean = new Clean();
            // 完成清洗
            clean.clean(names);

            Cooking cooking = new Cooking();
            // 完成烹饪
            cooking.cooking(names, foodName);
        }
    }
}
