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
    /// Interaction logic for Target.xaml
    /// </summary>
    public partial class Target : UserControl
    {
        public Target()
        {
            InitializeComponent();
        }
        
        internal void Boom()
        {
            string uriString = "pack://application:,,,/Images/boom.jpg";
            image.Source = new BitmapImage(new Uri(uriString));
        }
    }
}
