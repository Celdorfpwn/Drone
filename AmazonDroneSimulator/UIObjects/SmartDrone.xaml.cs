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

namespace AmazonDroneSimulator.UIObjects
{
    /// <summary>
    /// Interaction logic for SmartDrone.xaml
    /// </summary>
    public partial class SmartDrone : UserControl
    {
        public SmartDrone(int x, int y, string identifier)
        {
            InitializeComponent();
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);
            text.Text = identifier;
            DroneMap.Map.Children.Add(this);
        }
    }
}
