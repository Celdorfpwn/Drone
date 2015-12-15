using AmazonDroneSimulator.CodeRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmazonDroneSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ValuesGrid.ItemsSource = DroneMemoryValue.Values;
        }

        private void Compile_Click(object sender, RoutedEventArgs e)
        {
            var lines = CodeTextBox.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Where(line => !String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line)).ToList();

            var compiled = Compilator.Complie(lines);

            StringBuilder builder = new StringBuilder();

            lines.ForEach(line => builder.Append(line).Append(Environment.NewLine));

            CodeTextBox.Text = builder.ToString();

            if(compiled)
            {
                DroneMemoryValue.Reset();
                Runner.RunCode(lines);
                ValuesGrid.ItemsSource = DroneMemoryValue.Values;
            }

        }
    }
}
