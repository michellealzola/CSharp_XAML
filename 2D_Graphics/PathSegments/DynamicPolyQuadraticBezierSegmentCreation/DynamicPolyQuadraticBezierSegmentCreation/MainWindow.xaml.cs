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

namespace DynamicPolyQuadraticBezierSegmentCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PathGeometry currentPathGeometry;
        private PathFigure currentPathFigure;
        private PolyQuadraticBezierSegment polyQuadraticBezierSegment;
        private bool isDrawing;
        private bool isAddingControlPoint;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(DrawingCanvas);

            if (!isDrawing )
            {
                Path path = new Path
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                currentPathGeometry = new PathGeometry();
                currentPathFigure = new PathFigure
                {
                    StartPoint = clickPoint,
                };

                polyQuadraticBezierSegment = new PolyQuadraticBezierSegment();
                polyQuadraticBezierSegment.Points.Add(clickPoint);

                currentPathFigure.Segments.Add(polyQuadraticBezierSegment);
                currentPathGeometry.Figures.Add(currentPathFigure);

                path.Data = currentPathGeometry;

                DrawingCanvas.Children.Add(path);

                isDrawing = true;
                isAddingControlPoint = true;
            }
            else
            {
                if (isAddingControlPoint)
                {
                    polyQuadraticBezierSegment.Points.Add(clickPoint);
                    isAddingControlPoint = false;
                }
                else
                {
                    polyQuadraticBezierSegment.Points.Add(clickPoint);
                    isAddingControlPoint = true;
                }
            }
        }

        private void DrawingCanvas_MOuseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && polyQuadraticBezierSegment.Points.Count > 1)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);

                if (isAddingControlPoint)
                {
                    polyQuadraticBezierSegment.Points[polyQuadraticBezierSegment.Points.Count - 1] = currentPoint;
                }
                else
                {
                    polyQuadraticBezierSegment.Points[polyQuadraticBezierSegment.Points.Count - 2] = currentPoint;
                }

                DrawingCanvas.InvalidateVisual();   
            }

        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                Point releasePoint = e.GetPosition(DrawingCanvas);

                if (isAddingControlPoint)
                {
                    polyQuadraticBezierSegment.Points[polyQuadraticBezierSegment.Points.Count - 1] = releasePoint;
                }
                else
                {
                    polyQuadraticBezierSegment.Points[polyQuadraticBezierSegment.Points.Count - 2] = releasePoint;
                }

                isDrawing = false;
            }
        }
    }
}