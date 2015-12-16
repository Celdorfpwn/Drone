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

        public MyDrone(int x,int y)
        {
            InitializeComponent();
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);
            DroneMap.Map.Children.Add(this);
        }

        public bool Move(int direction)
        {
            MoveDirection(direction);
            DroneMap.Update();
            Thread.Sleep(300);
            return ReachedTarget();
        }

        private void MoveDirection(int direction)
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
        }


        private bool ReachedTarget()
        {
            if(X == DroneMap.Target.X && Y == DroneMap.Target.Y)
            {
                DroneMap.DestroyTarget();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Left()
        {
            Grid.SetColumn(this, X - 1);
            ConsoleView.Write("Left");
        }

        private void Right()
        {
            Grid.SetColumn(this, X + 1);
            ConsoleView.Write("Right");
        }

        private void Down()
        {
            Grid.SetRow(this, Y + 1);
            ConsoleView.Write("Down");
        }

        private void Up()
        {
            Grid.SetRow(this, Y - 1);
            ConsoleView.Write("Up");
        }

    }
}
