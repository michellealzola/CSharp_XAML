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

namespace BasicPolyBezierSegment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreatePolyBezierSegment();
        }

        private void CreatePolyBezierSegment()
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

            PolyBezierSegment polyBezierSegment = new PolyBezierSegment
            {
                Points = new PointCollection(new Point[]
                {
                    new Point(50, 300),
                    new Point(150, 350),
                    new Point(200, 300)
                }),
                IsStroked = true,

            };
            
            pathSegmentCollection.Add(polyBezierSegment);

            pathFigure.Segments = pathSegmentCollection;

            pathFigureCollection.Add(pathFigure);   

            pathGeometry.Figures = pathFigureCollection;

            path.Data = pathGeometry;

            DrawingCanvas.Children.Add(path);
        }
    }
}