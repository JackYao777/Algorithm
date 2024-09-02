using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.命令模式
{
    public class PlayPianoCommand : Command
    {
        private BingBingReceiver bingBing;

        public PlayPianoCommand(BingBingReceiver bingBing)
        {
            this.bingBing = bingBing;
        }
        public void Execute()
        {
            bingBing.PlayPiano();
        }
    }
}
