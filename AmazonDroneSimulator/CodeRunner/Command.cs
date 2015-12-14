using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator.CodeRunner
{
    public class Command
    {

        public Command(CommandsEnum type,string value)
        {
            Type = type;
            Value = value;
        }

        public CommandsEnum Type { get; private set; }

        public string Value { get; private set; }

        public void Execute()
        {
            switch(Type)
            {
                case CommandsEnum.LDN:
                    Commander.LDN(Value);
                    break;
                case CommandsEnum.STA:
                    Commander.STA(Value);
                    break;
                case CommandsEnum.LDA:
                    Commander.LDA(Value);
                    break;
                case CommandsEnum.ADDA:
                    Commander.ADDA(Value);
                    break;
                default:
                    break;
            }
        }
    }
}
