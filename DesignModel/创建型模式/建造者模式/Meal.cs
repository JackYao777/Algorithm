using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.建造者模式
{
    public class Meal
    {
        private List<Item> items = new List<Item>();

        public void AddItems(Item item)
        {
            items.Add(item);
        }

        public float GetCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            {
                cost = item.Price() + cost;
            }
            return cost;
        }

        public void ShowItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"名称{item.Name}");
                Console.WriteLine($"价格{item.Price()}");
                Console.WriteLine($"打包方式{item.Packing().Pack()}");
            }
        }
    }
}
