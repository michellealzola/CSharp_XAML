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

namespace DynamicPolyBezierSegmentCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PathFigure currentPathFigure;
        private PathGeometry currentPathGeometry;
        private PolyBezierSegment polyBezierSegment;
        private bool isDrawing;
        private Point lastPoint;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(DrawingCanvas);
            if (!isDrawing)
            {
                // Start a new path
                Path path = new Path
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                currentPathGeometry = new PathGeometry();
                currentPathFigure = new PathFigure
                {
                    StartPoint = clickPoint
                };

                polyBezierSegment = new PolyBezierSegment();
                polyBezierSegment.Points.Add(clickPoint);

                currentPathFigure.Segments.Add(polyBezierSegment);
                currentPathGeometry.Figures.Add(currentPathFigure);
                path.Data = currentPathGeometry;

                DrawingCanvas.Children.Add(path);
                lastPoint = clickPoint;
                isDrawing = true;
            }
            else
            {
                polyBezierSegment.Points.Add(clickPoint);
                lastPoint = clickPoint;
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && polyBezierSegment.Points.Count > 0)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);

                if (polyBezierSegment.Points.Count > 1)
                {
                    polyBezierSegment.Points[polyBezierSegment.Points.Count - 1] = currentPoint;
                }

                DrawingCanvas.InvalidateVisual();
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                Point releasePoint = e.GetPosition(DrawingCanvas);
                polyBezierSegment.Points.Add(releasePoint);
                lastPoint = releasePoint;
                isDrawing = false;
            }
        }
    }
}