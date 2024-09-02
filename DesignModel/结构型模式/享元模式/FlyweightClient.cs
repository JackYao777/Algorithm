using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.享元模式
{
    public class FlyweightClient
    {
        public void playChess()
        {
            //下黑子
            Chess backChess1 = ChessFactory.GetChess(Color.Black);
            backChess1.Draw(2, 5);

            //下白子
            Chess whiteChess = ChessFactory.GetChess(Color.White);
            whiteChess.Draw(3, 5);

            //下黑子
            Chess backChess2 = ChessFactory.GetChess(Color.Black);
            backChess2.Draw(2, 6);
        }
    }
}
