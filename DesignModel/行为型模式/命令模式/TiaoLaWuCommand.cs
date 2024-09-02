using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.命令模式
{
    public class TiaoLaWuCommand : Command
    {
        private MiMiReceiver daMiMi;

        public TiaoLaWuCommand(MiMiReceiver daMiMi, string duration)
        {
            this.daMiMi = daMiMi;
            this.duration = duration;
        }

        private String duration;//跳舞的时长
        public void Execute()
        {
            Console.WriteLine($"开始跳舞表演，时长为:{duration}");
            daMiMi.HotDance();
        }
    }
}
