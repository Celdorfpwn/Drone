using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator
{
    public static class Compilator
    {
        public static bool Complie(List<string> codeLines)
        {
            for(var index = 0;index < codeLines.Count;index++)
            {
                codeLines[index] = codeLines[index].TrimEnd();
                if(!CheckLine(codeLines[index]))
                {
                    codeLines[index] += " Error";
                    return false;
                }
            }
            return true;
        }

        private static bool CheckLine(string line)
        {
            return true;
            if (line != CommandsEnum.HLT.ToString())
            {

                var comands = line.Split(' ');

                if (comands.Count() > 1)
                {
                    if (Enum.GetNames(typeof(CommandsEnum)).Contains(comands[0]))
                    {
                        int ret = 0;
                        if (IsMemoryIdentificator(comands[1]))
                        {

                            return int.TryParse(comands[1].Replace("[", String.Empty).Replace("]", string.Empty), out ret);
                        }
                        else
                        {
                            return int.TryParse(comands[1], out ret);
                        }
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsMemoryIdentificator(string line)
        {
            if(line == "N")
            {
                return true;
            }
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                return line.Contains("[") && line.Contains("]") && line.Count(c => c == '[') == 1 && line.Count(c => c == ']') == 1;
            }
            else
            {
                return false;
            }
        }

        public static string GetNumberFromMemoryIdentificator(string memory)
        {
            return memory.Replace("[", String.Empty).Replace("]", string.Empty);
        }
        

    }
}
