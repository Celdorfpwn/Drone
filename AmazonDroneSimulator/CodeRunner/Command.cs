using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator.CodeRunner
{
    public class Command
    {

        public Command(CommandsEnum type,string value,int index)
        {
            Type = type;
            Value = value;
            Index = index;
        }

        public int Index { get; private set; }

        public CommandsEnum Type { get; private set; }

        public string Value { get; private set; }

        public int Execute()
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
                case CommandsEnum.SUBA:
                    Commander.SUBA(Value);
                    break;
                case CommandsEnum.JGE:
                    if(Commander.DoJGE())
                    {
                        return Commander.JGE(Value);
                    }
                    break;
                case CommandsEnum.HLT:
                    return Commander.HLT();
                default:
                    break;
            }

            return Index + 1;
        }
    }
}
