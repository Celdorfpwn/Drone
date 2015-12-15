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
    /// Interaction logic for Obstacle.xaml
    /// </summary>
    public partial class Obstacle : UserControl
    {
        public int X
        {
            get
            {
                return Grid.GetColumn(this);
            }
        }

        public int Y
        {
            get
            {
                return Grid.GetRow(this);
            }
        }

        public Obstacle(int x, int y)
        {
            InitializeComponent();
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);
            DroneMap.Map.Children.Add(this);
        }

        internal void CrashDrone()
        {
            string uriString = "pack://application:,,,/Images/crash.jpg";
            Image.Source = new BitmapImage(new Uri(uriString));
        }
    }
}
