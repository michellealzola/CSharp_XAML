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

namespace DynamicLineSegmentCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PathFigure currentPathFigure;
        private PathGeometry currentPathGeometry;
        private bool isDrawing;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isDrawing)
            {
                Point startPoint = e.GetPosition(DrawingCanvas);

                Path path = new Path
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                currentPathGeometry = new PathGeometry();

                currentPathFigure = new PathFigure
                {
                    StartPoint = startPoint,
                };

                LineSegment lineSegment = new LineSegment
                {
                    Point = startPoint,
                    IsStroked = true,
                };

                currentPathFigure.Segments.Add(lineSegment);

                currentPathGeometry.Figures.Add(currentPathFigure);

                path.Data = currentPathGeometry;

                DrawingCanvas.Children.Add(path);

                isDrawing = true;
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);

                LineSegment lineSegment = (LineSegment)currentPathFigure.Segments[0];

                lineSegment.Point = currentPoint;

                DrawingCanvas.InvalidateVisual();
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
            }
        }
    }
}