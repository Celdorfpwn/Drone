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
using System.IO;
using Newtonsoft.Json;
using System.Windows.Threading;

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
            ConsoleView.TextBox = ConsoleBox;
        }

        private void Compile_Click(object sender, RoutedEventArgs e)
        {
            var lines = CodeTextBox.Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Where(line => !String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line)).ToList();

            var compiled = Compilator.Complie(lines);

            WriteCodeLines(lines);

            if(compiled)
            {
                DroneMemoryValue.Reset();
                Runner.RunCode(lines);
                ValuesGrid.ItemsSource = DroneMemoryValue.Values;
            }
        }

        private void WriteCodeLines(List<string> lines)
        {
            StringBuilder builder = new StringBuilder();

            lines.ForEach(line => builder.Append(line).Append(Environment.NewLine));

            CodeTextBox.Text = builder.ToString();
        }

        private void SelectMap_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = @"E:\SideProjects\AmazonDrone\Maps";
            dlg.DefaultExt = ".jsonmap";

            if (dlg.ShowDialog() == true)
            {
                LoadMap(dlg.FileName);
            }

        }

        private void LoadMap(string fileName)
        {
            DroneMap.InitMap(MapGrid, File.ReadAllText(fileName));
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = @"E:\SideProjects\AmazonDrone\Maps";
            if (dlg.ShowDialog() == true)
            {
                WriteCodeLines(File.ReadAllLines(dlg.FileName).ToList());
            }
        }
    }
}
