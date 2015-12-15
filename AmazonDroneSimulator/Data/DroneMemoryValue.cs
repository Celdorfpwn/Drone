using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonDroneSimulator
{
    public class DroneMemoryValue : INotifyPropertyChanged
    {
        public string Key { get; set; }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value =  value;
                NotifyPropertyChanged("Value");
            }
        }


        private int _value { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                  new PropertyChangedEventArgs(propertyName));
            }
        }

        public static void Reset()
        {
            if (_values != null)
            {
                ConsoleView.Clear();
                foreach(var value in _values)
                {
                    value.Value = 0;
                }
            }

        }

        private static void Build()
        {
            _values.Add(new DroneMemoryValue { Key = "A" });
            _values.Add(new DroneMemoryValue { Key = "N" });

            for (var index = 0; index < 2000; index++)
            {
                _values.Add(new DroneMemoryValue { Key = "[" + index + "]" });
            }
        }

        public static List<DroneMemoryValue> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new List<DroneMemoryValue>();
                    Build();

                }

                return _values;

            }
        }

        private static List<DroneMemoryValue> _values;
    }
}
