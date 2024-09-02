using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.命令模式
{
    public class DogWang2Client
    {
        public void EnjoySexRobot()
        {
            //robot 控制系统，用户通过此系统来发出命令
            RobotInvoker invoker = new RobotInvoker();

            //生成唱歌弹琴命令
            BingBingReceiver bingBingReceiver = new BingBingReceiver();
            SingSongCommand singSongCommand = new SingSongCommand(bingBingReceiver);
            PlayPianoCommand playPianoCommand = new PlayPianoCommand(bingBingReceiver);
            //构建执行计划
            invoker.AddCommands(singSongCommand);
            invoker.AddCommands(playPianoCommand);
            //执行命令
            invoker.ExecuteCommand();
            //生成跳舞命令


            //执行命令
            invoker.ExecuteCommand();
        }
    }
}
