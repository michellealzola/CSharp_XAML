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

namespace BasicQuadraticBezierSegment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateQuadraticBezierSegment();
        }

        private void CreateQuadraticBezierSegment()
        {
            Path path = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(10, 50),
            };

            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();

            QuadraticBezierSegment quadraticBezierSegment = new QuadraticBezierSegment
            {
                Point1 = new Point(100, 400),
                Point2 = new Point(200, 450),
                IsStroked = true,

            };

            pathSegmentCollection.Add(quadraticBezierSegment);

            pathFigure.Segments = pathSegmentCollection;

            pathFigureCollection.Add(pathFigure);   

            pathGeometry.Figures = pathFigureCollection;

            path.Data = pathGeometry;

            DrawingCanvas.Children.Add(path);
        }
    }
}