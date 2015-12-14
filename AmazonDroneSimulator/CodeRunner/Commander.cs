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

        static Commander()
        {
            Memory = DroneMemoryValue.Values;
        }
        

        private static List<DroneMemoryValue> Memory { get; set; }

        public static void LDN(string value)
        {
            Memory[IndexN].Value = GetAssignValue(value);
        }

        public static void LDA(string value)
        {
            Memory[IndexA].Value = GetAssignValue(value);

        }

        public static void STA(string value)
        {
            var index = GetIndexFromIdentificator(value);
            Memory[index].Value = Memory[IndexA].Value;
        }

        public static void ADDA(string value)
        {
            Memory[IndexA].Value += GetAssignValue(value);
        }

        public static void SUBA(string value)
        {
            Memory[IndexA].Value -= GetAssignValue(value);
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
