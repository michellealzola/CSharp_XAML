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

namespace OverlayingDrawings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _startPoint;
        private Path _currentPath;
        private GeometryGroup _geometryGroup;
        private Geometry _currentGeometry;

        public MainWindow()
        {
            InitializeComponent();
            _geometryGroup = new GeometryGroup();
        }

        private void InitializeCurrentPath()
        {
            _currentPath = new Path
            {
                Data = _currentGeometry,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(_currentPath);
        }

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentGeometry = new RectangleGeometry();
            InitializeCurrentPath();
        }

        private void DrawEllipseButton_Click(object sender, RoutedEventArgs e)
        {
            _currentGeometry = new EllipseGeometry();
            InitializeCurrentPath();
        }

        private void DrawLineButton_Click(object sender, RoutedEventArgs e)
        {
            _currentGeometry = new LineGeometry();
            InitializeCurrentPath();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentGeometry != null)
            {
                _startPoint = e.GetPosition(DrawingCanvas);

                if (_currentGeometry is LineGeometry line)
                {
                    line.StartPoint = _startPoint;
                    line.EndPoint = _startPoint;
                }
            }
            else if (_currentGeometry is RectangleGeometry rectangle)
            {
                rectangle.Rect = new Rect(_startPoint, new Size(0, 0));

            }
            else if (_currentGeometry is EllipseGeometry ellipse)
            {
                ellipse.Center = _startPoint;
                ellipse.RadiusX = 0;
                ellipse.RadiusY = 0;
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _currentGeometry != null)
            {
                var pos = e.GetPosition(DrawingCanvas);

                if (_currentGeometry is LineGeometry line)
                {
                    line.EndPoint = pos;
                }
                else if (_currentGeometry is RectangleGeometry rectangle)
                {
                    rectangle.Rect = new Rect(_startPoint, pos);
                }
                else if (_currentGeometry is EllipseGeometry ellipse)
                {
                    //ellipse.Center = pos;
                    //ellipse.RadiusX = Math.Abs(pos.X - _startPoint.X);
                    //ellipse.RadiusY = Math.Abs(pos.Y - _startPoint.Y);

                    ellipse.Center = new Point((_startPoint.X + pos.X) / 2, (_startPoint.Y + pos.Y) / 2);
                    ellipse.RadiusX = Math.Abs(pos.X - _startPoint.X) / 2;
                    ellipse.RadiusY = Math.Abs(pos.Y - _startPoint.Y) / 2;
                }
            }

        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_currentPath != null)
            {
                _geometryGroup.Children.Add(_currentGeometry);
                _currentPath = null;
                _currentGeometry = null;
            }
        }
    }
}