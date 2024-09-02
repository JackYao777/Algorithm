using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.外观模式
{
    public class Groceries
    {
        private List<String> names;

        public Groceries(List<String> names)
        {
            this.names = names;
        }

        public void buy()
        {
            Console.WriteLine("买了" + names + "菜");
        }
    }
}
