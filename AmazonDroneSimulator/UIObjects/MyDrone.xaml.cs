using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MyDrone.xaml
    /// </summary>
    public partial class MyDrone : UserControl
    {
        public MyDrone()
        {
            InitializeComponent();
        }

        internal bool Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    break;
                case 1:
                    Up();
                    break;
                case 2:
                    Right();
                    break;
                case 3:
                    Down();
                    break;
                case 4:
                    Left();
                    break;
            }

            return ReachedTarget();
        }

        private bool ReachedTarget()
        {
            return Grid.GetRow(this) == DroneMap.TargetRow && Grid.GetColumn(this) == DroneMap.TargetColumn;
        }

        private void Left()
        {
            Grid.SetColumn(this, Grid.GetColumn(this) - 1);
        }

        private void Right()
        {
            Grid.SetColumn(this, Grid.GetColumn(this) + 1);
        }

        private void Down()
        {
            Grid.SetRow(this, Grid.GetRow(this) + 1);
        }

        private void Up()
        {
            Grid.SetRow(this, Grid.GetRow(this) - 1);
        }

    }
}
