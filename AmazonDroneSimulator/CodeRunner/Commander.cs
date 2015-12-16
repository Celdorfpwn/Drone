using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator.CodeRunner
{
    public static class Commander
    {

        private const int IndexA = 0;
        private const int IndexN = 1;

        

        private static List<DroneMemoryValue> Memory
        {
            get
            {
                return DroneMemoryValue.Values;
            }
        }

        public static void LDN(string value)
        {
            Memory[IndexN].Value = GetAssignValue(value);

            //ConsoleView.Write("N = " + Memory[IndexN].Value);
        }

        public static void LDA(string value)
        {
            Memory[IndexA].Value = GetAssignValue(value);

            //ConsoleView.Write("A = " + Memory[IndexA].Value);

        }

        public static void STA(string value)
        {
            var index = GetIndexFromIdentificator(value);
            Memory[index].Value = Memory[IndexA].Value;

            //ConsoleView.Write("["+ Memory[index].Value +"] = " + Memory[IndexA].Value);

        }

        public static void ADDA(string value)
        {
            Memory[IndexA].Value += GetAssignValue(value);
            //ConsoleView.Write("A += " + GetAssignValue(value));
        }

        public static void SUBA(string value)
        {
            Memory[IndexA].Value -= GetAssignValue(value);
            //ConsoleView.Write("A -= " + GetAssignValue(value));
        }

        internal static int HLT()
        {
            if (DroneMap.Drone.Move(Memory[2].Value))
            {
                return -3;
            }
            else if (DroneMap.IsDroneCrashed())
            {
                return -2;
            }
            else
            {
                return -1;
            }
            
        }

        public static int GetAssignValue(string value)
        {
            if (Compilator.IsMemoryIdentificator(value))
            {
                var index = GetIndexFromIdentificator(value);
                return Memory[index].Value;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

        public static int JGE(string value)
        {
            ConsoleView.Write("Jump to line " + GetAssignValue(value));
            return GetAssignValue(value);
        }

        public static bool DoJGE()
        {
            return Memory[IndexA].Value >= 0;
        }

        private static int GetIndexFromIdentificator(string value)
        {
            var identificator = Compilator.GetNumberFromMemoryIdentificator(value);
            if (identificator == "N")
            {
                return IndexN;
            }
            else if (identificator == "A")
            {
                return IndexA;
            }
            else
            {
                return Convert.ToInt32(identificator)+2;
            }
        }
        
    }
}
