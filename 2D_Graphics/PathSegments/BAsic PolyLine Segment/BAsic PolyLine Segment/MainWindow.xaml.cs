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

namespace BAsic_PolyLine_Segment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddPolyLineSegment();
        }

        private void AddPolyLineSegment()
        {
            Path path = new Path
            {
                Stroke = Brushes.CadetBlue,
                StrokeThickness = 2,
            };

            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(10, 50),
            };

            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();

            PolyLineSegment polyLineSegment = new PolyLineSegment
            {
                Points = new PointCollection(new Point[] { new Point(200, 100), new Point(10, 100) }),
                IsStroked = true,
            };

            pathSegmentCollection.Add(polyLineSegment);

            pathFigure.Segments = pathSegmentCollection;

            pathFigureCollection.Add(pathFigure);

            pathGeometry.Figures = pathFigureCollection;

            path.Data = pathGeometry;

            DrawingCanvas.Children.Add(path);

        }
    }
}