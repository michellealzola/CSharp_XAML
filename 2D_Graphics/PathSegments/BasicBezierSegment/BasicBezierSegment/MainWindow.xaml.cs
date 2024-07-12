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

namespace BasicBezierSegment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateBezierSegment();
        }

        private void CreateBezierSegment()
        {
            Path path = new Path
            {
                Stroke = Brushes.Aquamarine,
                StrokeThickness = 2,
            };

            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(10, 50),
            };

            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();

            BezierSegment bezierSegment = new BezierSegment
            {
                Point1 = new Point(100, 200),
                Point2 = new Point(300, 200),
                Point3 = new Point(200, 250),
                IsStroked = true,

            };

            pathSegmentCollection.Add(bezierSegment);

            pathFigure.Segments = pathSegmentCollection;

            pathFigureCollection.Add(pathFigure);

            pathGeometry.Figures = pathFigureCollection;

            path.Data = pathGeometry;

            DrawingCanvas.Children.Add(path);
        }
    }
}