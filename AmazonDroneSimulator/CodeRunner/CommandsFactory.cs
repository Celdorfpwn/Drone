using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator.CodeRunner
{
    public static class CommandsFactory
    {
        internal static IEnumerable<Command> Create(IEnumerable<string> codeLines)
        {
            foreach(var line in codeLines)
            {
                var commands = line.Split(' ');
                yield return new Command((CommandsEnum)Enum.Parse(typeof(CommandsEnum),commands[0]), commands[1]);
            }
        }
    }
}
