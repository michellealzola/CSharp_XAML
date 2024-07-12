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

namespace DynamicArcSegmentCreation
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

                ArcSegment arcSegment = new ArcSegment
                {
                    Point = startPoint,
                    Size = new Size(50, 50),
                    RotationAngle = 45,
                    SweepDirection = SweepDirection.Clockwise,
                    IsStroked = true
                };

                currentPathFigure.Segments.Add(arcSegment);

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
                ArcSegment arcSegment = (ArcSegment)currentPathFigure.Segments[0];
                arcSegment.Point = currentPoint;

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