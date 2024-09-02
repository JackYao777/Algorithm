using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.享元模式
{
    public class WhiteChess : Chess
    {
        private Color Color = Color.White;

        private const String Sharp = "圆形";

        public WhiteChess()
        {
        }

        public Color getColor()
        {
            return Color;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"棋子置于（{x}，{y}）处");
        }
    }
}
