using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DesignModel.行为型模式.命令模式
{
    public class RobotInvoker
    {
        private List<Command> setRobotCommands = new List<Command>();

        public void CelarCommand()
        {
            setRobotCommands.Clear();
        }

        public void AddCommands(Command command)
        {
            setRobotCommands.Add(command);
        }

        public void ExecuteCommand()
        {
            foreach (Command command in setRobotCommands)
            {
                command.Execute();
            }
        }
    }
}
