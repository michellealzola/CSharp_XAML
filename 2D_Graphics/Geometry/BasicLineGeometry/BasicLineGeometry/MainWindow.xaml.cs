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

namespace BasicLineGeometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateLineGeometry();
        }

        private void CreateLineGeometry()
        {
            double startPointX = 300;
            double startPointY = 10;
            double endPointX = 400;
            double endPointY = 60;

            Point startPointCoordinate = new Point(startPointX, startPointY);
            Point endPointCoordinate = new Point(endPointX, endPointY);

            LineGeometry lineGeometry = new LineGeometry(startPointCoordinate, endPointCoordinate);

            Path path = new Path
            {
                Data = lineGeometry,
                Stroke = Brushes.Brown,
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(path);
        }
    }
}