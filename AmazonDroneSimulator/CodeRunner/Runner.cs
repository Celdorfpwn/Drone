using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator.CodeRunner
{
    public static class Runner
    {
        public static void RunCode(IEnumerable<string> codeLines)
        {
            var commands = CommandsFactory.Create(codeLines);
            int index = 0;
            var codelimit = commands.Count();

            var limit = int.MaxValue;
            int comandsExecutedCount = 0;


            while (index < codelimit && comandsExecutedCount <= limit)
            {
                index = commands.ElementAt(index).Execute();

                if (index == -1)
                {
                    index = 0;
                }
                else if(index == -2)
                {
                    ConsoleView.Write("-----------------");
                    ConsoleView.Write("Crashed");
                    break;
                }
                else if(index == -3)
                {
                    ConsoleView.Write("-----------------");
                    ConsoleView.Write("ISIS BOMBED & DESTROYED");
                    break;
                }

                comandsExecutedCount++;
            }

            ConsoleView.Write("-----------------");
            ConsoleView.Write(comandsExecutedCount + " commands");
            ConsoleView.Write("-----------------");
        }
    }
}
