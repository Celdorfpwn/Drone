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

        static DroneMap()
        {
            Obstacles = new List<Obstacle>();
            Citizens = new List<Citizen>();
        }


        public static Grid Map { get; private set; }

        public static MyDrone Drone { get; private set; }

        public static Target Target { get; private set; }

        public static List<Obstacle> Obstacles { get; private set; }

        public static List<Citizen> Citizens { get; private set; }

        public static int XLimit { get; private set; }

        public static int YLimit { get; private set; }

        public static void InitMap(Grid map, string json)
        {
            Map = map;
            ClearMap();

            dynamic data = JsonConvert.DeserializeObject(json);

            InitRowAndCols(data.map.cols, data.map.rows);
            SetDroneLocation(data.simulatedDrone.position.x, data.simulatedDrone.position.y);
            SetDroneTarget(data.map.target.x, data.map.target.y);
            if (data.map.objects != null)
            {
                SetOthers(data.map.objects);
            }
        }



        internal static void Update()
        {
            foreach (var citizen in Citizens.ToList())
            {
                citizen.Move();
            }

            Map.Refresh();
        }

        private static void ClearMap()
        {
            Map.Children.Clear();
            Map.RowDefinitions.Clear();
            Map.ColumnDefinitions.Clear();
            Obstacles.Clear();
        }

        private static void SetOthers(dynamic objects)
        {
            foreach (var obj in objects)
            {
                var type = (MapObjects)Enum.Parse(typeof(MapObjects), Convert.ToString(obj.type));
                switch (type)
                {
                    case MapObjects.Obstacle:
                        SetObstacle(obj);
                        break;
                    case MapObjects.Cetatean:
                        SetCetatean(obj);
                        break;
                }
            }
        }

        private static void SetCetatean(dynamic obj)
        {
            var x = Convert.ToInt32(Convert.ToString(obj.position.x));
            var y = Convert.ToInt32(Convert.ToString(obj.position.y));
            var direction = (Direction)Enum.Parse(typeof(Direction), Convert.ToString(obj.direction));
            Citizens.Add(new Citizen(x, y, direction));
        }


        private static void SetObstacle(dynamic obj)
        {
            var x = Convert.ToInt32(Convert.ToString(obj.position.x));
            var y = Convert.ToInt32(Convert.ToString(obj.position.y));
            Obstacles.Add(new Obstacle(x, y));
        }

        private static void SetDroneTarget(dynamic x, dynamic y)
        {
            var rowPos = Convert.ToInt32(Convert.ToString(x));
            var colPos = Convert.ToInt32(Convert.ToString(y));

            Target = new Target(rowPos, colPos);
        }

        internal static void DestroyTarget()
        {
            Target.Destroy();
        }

        internal static bool IsDroneCrashed()
        {
            foreach (var obstacle in Obstacles)
            {
                if (Drone.X == obstacle.X && Drone.Y == obstacle.Y)
                {
                    obstacle.CrashDrone();
                    return true;
                }
            }
            return false;
        }

        private static void SetDroneLocation(dynamic x, dynamic y)
        {
            var rowPos = Convert.ToInt32(Convert.ToString(x));
            var colPos = Convert.ToInt32(Convert.ToString(y));

            Drone = new MyDrone(rowPos, colPos);

        }

        private static void InitRowAndCols(dynamic cols, dynamic rows)
        {
            var colsCount = Convert.ToInt32(Convert.ToString(cols));
            var rowsCount = Convert.ToInt32(Convert.ToString(rows));

            XLimit = colsCount;
            YLimit = rowsCount;

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
