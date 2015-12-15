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
            var limit = commands.Count();
            while(index != -1 || index == limit)
            {
                index = commands.ElementAt(index).Execute();
            }
        }
    }
}
