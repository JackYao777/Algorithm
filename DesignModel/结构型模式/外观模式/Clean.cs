using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.外观模式
{
    /**
 * @see 做菜第二步，清洗菜品
 * @author Thornhill
 *
 */
    public class Clean
    {
        public void clean(List<String> names)
        {
            Console.WriteLine("洗" + names + "菜");
        }
    }
}
