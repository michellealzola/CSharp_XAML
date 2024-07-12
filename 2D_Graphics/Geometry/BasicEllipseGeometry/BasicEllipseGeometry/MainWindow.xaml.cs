using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasicEllipseGeometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateEllipseGeometry();
        }

        private void CreateEllipseGeometry()
        {
            double centerX = 200;
            double centerY = 75;
            double RadiusX = 50;
            double RadiusY = 25;

            EllipseGeometry ellipseGeometry = new EllipseGeometry(new Point(centerX, centerY), RadiusX, RadiusY);

            Path path = new Path
            {
                Data = ellipseGeometry,
                Fill = Brushes.Brown,
            };

            DrawingCanvas.Children.Add(path);
        }
    }
}