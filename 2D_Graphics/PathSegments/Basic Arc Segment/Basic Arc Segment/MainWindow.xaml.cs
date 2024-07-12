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

namespace Basic_Arc_Segment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateArcSegment();
        }

        private void CreateArcSegment()
        {
            Path path = new Path
            {
                Stroke = Brushes.Brown,
                StrokeThickness = 2,
            };

            PathGeometry pathGeometry = new PathGeometry();

            PathFigureCollection pathFigureCollection = new PathFigureCollection();

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(10, 50),
            };

            PathSegmentCollection pathSegmentCollection = new PathSegmentCollection();

            ArcSegment arcSegment = new ArcSegment
            {
                Point = new Point(150, 150),
                Size = new Size(50, 50),
                RotationAngle = 45,
                IsLargeArc = true,
                SweepDirection = SweepDirection.Clockwise,
                IsStroked = true,

            };

            pathSegmentCollection.Add(arcSegment);  

            pathFigure.Segments = pathSegmentCollection;

            pathFigureCollection.Add(pathFigure);

            pathGeometry.Figures = pathFigureCollection;

            path.Data = pathGeometry;

            DrawingCanvas.Children.Add(path);

        }

    }
}