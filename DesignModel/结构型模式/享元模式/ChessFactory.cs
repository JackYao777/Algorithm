using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.结构型模式.享元模式
{
    public class ChessFactory
    {
        private static Dictionary<Color, Chess> chessMap = new Dictionary<Color, Chess>();

        public static Chess GetChess(Color color)
        {
            Chess chess = chessMap.GetValueOrDefault(color);
            if (chess == null)
            {
                chess = color == Color.White ? new WhiteChess() : new BlackChess();
                chessMap.Add(color, chess);
            }
            return chess;
        }
    }
}
