using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.外观模式
{
    /**
 * @see 做菜第三步，烹饪出锅
 * @author Thornhill
 *
 */
    public class Cooking
    {
        public void cooking(List<String> names, String foodName)
        {
            Console.WriteLine("烹饪" + names + "食材，" + "产出" + foodName);
        }
    }
}
