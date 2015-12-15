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
            var index = 0;
            foreach(var line in codeLines)
            {
                var splitLine = line.Split(' ');

                if (splitLine.Count() > 1)
                {
                    yield return new Command((CommandsEnum)Enum.Parse(typeof(CommandsEnum), splitLine[0]), splitLine[1], index++);
                } 
                else
                {
                    yield return new Command(CommandsEnum.HLT, String.Empty, index++);
                }
            }
        }
    }
}
