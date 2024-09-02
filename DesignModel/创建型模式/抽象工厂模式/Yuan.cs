using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.创建型模式.抽象工厂模式
{
    public class Yuan : ISharp
    {
        public void Draw()
        {
            Console.WriteLine("圆");
        }
    }
}
