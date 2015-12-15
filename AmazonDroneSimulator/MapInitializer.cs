using System;
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
using AmazonDroneSimulator.UIObjects;

namespace AmazonDroneSimulator
{
    public static class DroneMap
    {

        public static Grid Map { get; private set; }

        public static MyDrone Drone { get; private set; }

        private static Target Target { get; set; }

        public static int TargetRow
        {
            get
            {
                return Grid.GetRow(Target);
            }
        }

        public static int TargetColumn
        {
            get
            {
                return Grid.GetColumn(Target);
            }
        }

        public static void InitMap(Grid map, string json)
        {
            Map = map;
            dynamic data = JsonConvert.DeserializeObject(json);

            InitRowAndCols(data.map.cols, data.map.rows);
            SetDroneLocation(data.simulatedDrone.position.x, data.simulatedDrone.position.y);
            SetDroneTarget(data.map.target.x, data.map.target.y);
        }

        private static void SetDroneTarget(dynamic x, dynamic y)
        {
            var rowPos = Convert.ToInt32(Convert.ToString(x));
            var colPos = Convert.ToInt32(Convert.ToString(y));

            Target = new Target();
            Grid.SetRow(Target, rowPos);
            Grid.SetColumn(Target, colPos);
            Map.Children.Add(Target);
        }

        private static void SetDroneLocation(dynamic x, dynamic y)
        {
            var rowPos = Convert.ToInt32(Convert.ToString(x));
            var colPos = Convert.ToInt32(Convert.ToString(y));

            Drone = new MyDrone();
            Grid.SetRow(Drone, rowPos);
            Grid.SetColumn(Drone, colPos);
            Map.Children.Add(Drone);

        }

        private static void InitRowAndCols(dynamic cols, dynamic rows)
        {
            var colsCount = Convert.ToInt32(Convert.ToString(cols));
            var rowsCount = Convert.ToInt32(Convert.ToString(rows));


            for (var count = 0; count < colsCount; count++)
            {
                Map.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (var count = 0; count < rowsCount; count++)
            {
                Map.RowDefinitions.Add(new RowDefinition());
            }

            Map.ShowGridLines = true;

        }
    }
}
