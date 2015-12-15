using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AmazonDroneSimulator
{
    public static class ConsoleView
    {
        public static TextBox TextBox { private get; set; }

        public static void Write(string value)
        {
            if (TextBox!=null)
            {
                TextBox.Text += value + Environment.NewLine;
                TextBox.Refresh();
            }
        }

        public static void Clear()
        {
            TextBox.Text = String.Empty;
        }
    }
}
