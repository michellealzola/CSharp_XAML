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

namespace LineIntersectionDetection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private LineGeometry currentlineGeometry;
        private Path currentPath;
        private LineGeometry line1, line2;
        private int lineCount = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isDrawing && lineCount < 2)
            {
                Point startPoint = e.GetPosition(DrawingCanvas);

                currentlineGeometry = new LineGeometry
                {
                    StartPoint = startPoint,
                    EndPoint = startPoint
                };

                currentPath = new Path
                {
                    Data = currentlineGeometry,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };
                
                DrawingCanvas.Children.Add(currentPath);
                isDrawing = true;

            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && currentlineGeometry != null)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                currentlineGeometry.EndPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;

                if (lineCount == 0)
                {
                    line1 = currentlineGeometry;
                }
                else if (lineCount == 1)
                {
                    line2 = currentlineGeometry;
                    DetectIntersection();
                }

                lineCount++;
                currentlineGeometry = null;
                currentPath = null;
            }
        }

        private bool IsBetween(double start, double end, double point)
        {
            return (start <= point && point <= end) || (end <= point && point <= start);
        }
        private Point? GetIntersectionPoint(LineGeometry line1, LineGeometry line2)
        {
            double x1 = line1.StartPoint.X;
            double y1 = line1.StartPoint.Y;

            double x2 = line1.EndPoint.X;
            double y2 = line1.EndPoint.Y;

            double x3 = line2.StartPoint.X;
            double y3 = line2.StartPoint.Y;

            double x4 = line2.EndPoint.X;
            double y4 = line2.EndPoint.Y;

            double denom = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (denom == 0)
            {
                return null;
            }

            double intersectX = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denom;
            double intersectY = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denom;

            if (IsBetween(x1, x2, intersectX) &&
                IsBetween(y1, y2, intersectY) &&
                IsBetween(x3, x4, intersectX) &&
                IsBetween(y3, y4, intersectY))
            {
                return new Point(intersectX, intersectY);
            }

            return null;
        }

        private void DetectIntersection()
        {
            if (line1 != null && line2 != null)
            {
                Point? intersection = GetIntersectionPoint(line1, line2);

                if (intersection.HasValue)
                {
                    IntersectionPoint.SetValue(Canvas.LeftProperty, intersection.Value.X - IntersectionPoint.Width / 2);
                    IntersectionPoint.SetValue(Canvas.TopProperty, intersection.Value.Y - IntersectionPoint.Height / 2);
                    IntersectionPoint.Visibility = Visibility.Visible;
                }
                else
                {
                    IntersectionPoint.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}