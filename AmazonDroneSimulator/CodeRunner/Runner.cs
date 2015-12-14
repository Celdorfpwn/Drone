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

            foreach(var command in commands)
            {
                command.Execute();
            }
        }
    }
}
