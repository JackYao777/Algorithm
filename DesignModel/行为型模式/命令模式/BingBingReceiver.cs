using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.命令模式
{
    public class BingBingReceiver
    {
        public void SingSong()
        {
            Console.WriteLine("落花满天蔽月光 借一杯附荐凤台上...");
        }

        public void PlayPiano()
        {
            Console.WriteLine("随着BingBing纤细的双手在琴弦上来回撩拨，美妙的音乐响彻了整个房间...");

            List<int> nums = new List<int>();
        }
    }
}
