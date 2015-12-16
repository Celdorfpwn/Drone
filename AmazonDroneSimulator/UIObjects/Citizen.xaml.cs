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
    /// Interaction logic for Citizen.xaml
    /// </summary>
    public partial class Citizen : UserControl
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

        public Direction Direction { get; private set; }

        public Citizen(int x, int y,Direction direction)
        {
            InitializeComponent();
            Direction = direction;
            Grid.SetColumn(this, x);
            Grid.SetRow(this, y);
            DroneMap.Map.Children.Add(this);
        }

        public void Move()
        {
            switch(Direction)
            {
                case Direction.UP:
                    Up();
                    break;
                case Direction.DOWN:
                    Down();
                    break;
                case Direction.LEFT:
                    Left();
                    break;
                case Direction.RIGHT:
                    Right();
                    break;
            }
        }

        public bool CanShootDrone(int droneX,int droneY)
        {
            foreach(var value in ShootingRange())
            {
                if( value.Item1 == droneY && value.Item2 == droneX)
                {
                    return true;
                }
            }
            return false;
        }

        private List<Tuple<int,int>> ShootingRange()
        {
            List<Tuple<int, int>> range = new List<Tuple<int, int>>();

            for(var y = Y-3;y<=Y+3;y++)
            {
                for(var x = X-3;x<=X+3;x++)
                {
                    range.Add(new Tuple<int, int>(y,x));
                }
            }
            return range;
        }

        private void RemoveFromMap()
        {
            DroneMap.Citizens.Remove(this);
            DroneMap.Map.Children.Remove(this);
        }

        private void Left()
        {
            var nextPos = X - 1;
            if (nextPos < 0)
            {
                RemoveFromMap();
            }
            else
            {
                Grid.SetColumn(this, nextPos);
            }
        }

        private void Right()
        {
            var nextPos = X + 1;
            if (nextPos > DroneMap.XLimit)
            {
                RemoveFromMap();
            }
            else
            {
                Grid.SetColumn(this, nextPos);
            }
           
        }

        private void Down()
        {
            var nextPos = Y + 1;
            if (nextPos > DroneMap.YLimit)
            {
                RemoveFromMap();
            }
            else
            {
                Grid.SetRow(this, nextPos);
            }
        }

        private void Up()
        {
            var nextPos = Y - 1;
            if (nextPos < 0)
            {
                RemoveFromMap();
            }
            else
            {
                Grid.SetRow(this, Y - 1);
            }
        }
    }
}
