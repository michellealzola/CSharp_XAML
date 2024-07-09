using System.Drawing;
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


namespace InteractivePolyline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline currentPolyline;
        private Ellipse movingPoint;
        private PointCollection polylinePoints;
        private bool isDragging;
        public MainWindow()
        {
            InitializeComponent();
            InitializePolyline();
        }

        private void InitializePolyline()
        {
            currentPolyline = new Polyline
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            DrawingCanvas.Children.Add(currentPolyline);

            polylinePoints = new PointCollection();
            currentPolyline.Points = polylinePoints;

            DrawingCanvas.MouseLeftButtonDown += DrawingCanvas_MouseLeftButtonDown;
            DrawingCanvas.MouseMove += DrawingCanvas_MouseMove;
            DrawingCanvas.MouseLeftButtonUp += DrawingCanvas_MouseLeftButtonUp;

        }

        private Ellipse CreatePoinEllipse(System.Windows.Point position)
        {
            Ellipse ellipse = new Ellipse
            {
                Width = 10,
                Height = 10,
                Fill = Brushes.Blue,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Tag = position
            };

            Canvas.SetLeft(ellipse, position.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, position.Y - ellipse.Height / 2);    

            return ellipse;
        }

        private bool IsPointClose(System.Windows.Point p1, System.Windows.Point p2, double threshold = 10)
        {
            return (p1 - p2).Length < threshold;
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point clickPosition = e.GetPosition(DrawingCanvas);

            foreach (System.Windows.Point point in polylinePoints)
            {
                if (IsPointClose(point, clickPosition))
                {
                    isDragging = true;
                    movingPoint = CreatePoinEllipse((System.Windows.Point) point);
                    DrawingCanvas.Children.Add(movingPoint);
                    return;
                }
            }

            polylinePoints.Add(clickPosition);
            DrawingCanvas.Children.Add(CreatePoinEllipse((System.Windows.Point) clickPosition));
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && movingPoint != null)
            {
                System.Windows.Point mousePosition = e.GetPosition(DrawingCanvas);
                movingPoint.SetValue(Canvas.LeftProperty, mousePosition.X - movingPoint.Width / 2);
                movingPoint.SetValue(Canvas.TopProperty, mousePosition.Y - movingPoint.Height / 2);

                for (int i = 0; i < polylinePoints.Count; i++)
                {
                    if (IsPointClose(polylinePoints[i], (System.Windows.Point)movingPoint.Tag))
                    {
                        polylinePoints[i] = mousePosition;
                        currentPolyline.Points = polylinePoints;
                        return;
                    }
                }
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                DrawingCanvas.Children.Remove(movingPoint);
                movingPoint = null;
                isDragging = false;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
            InitializePolyline();
        }
    }
}