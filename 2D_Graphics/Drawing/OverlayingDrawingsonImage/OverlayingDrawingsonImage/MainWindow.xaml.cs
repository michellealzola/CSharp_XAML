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

namespace OverlayingDrawingsonImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _startPoint;
        private Geometry _currentGeometry;
        private DrawingGroup _drawingGroup;
        private GeometryDrawing _currentGeometryDrawing;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                InitializeImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing image: " + ex.Message);
            }
        }

        private void InitializeImage()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri("F:\\AdobeIllustrator\\WinterClipart01_ECA\\WinterClipart01_ECA-BonusBackground.jpg", UriKind.RelativeOrAbsolute));

            ImageControl.Source = bitmapImage;

            ImageControl.Width = bitmapImage.Width;
            ImageControl.Height = bitmapImage.Height;

            _drawingGroup = new DrawingGroup();

            ImageDrawing imageDrawing = new ImageDrawing(bitmapImage, new Rect(0, 0, bitmapImage.Width, bitmapImage.Height));

            _drawingGroup.Children.Add(imageDrawing);

            DrawingImage drawingImage = new DrawingImage(_drawingGroup);
            ImageControl.Source = drawingImage;
        }

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            _currentGeometry = new RectangleGeometry();
            _currentGeometryDrawing = new GeometryDrawing
            {
                Geometry = _currentGeometry,
                Pen = new Pen(Brushes.Coral, 2)
            };

            _drawingGroup.Children.Add(_currentGeometryDrawing);
        }

        private void DrawEllipseButton_Click(object sender, RoutedEventArgs e)
        {
            _currentGeometry = new EllipseGeometry();
            _currentGeometryDrawing = new GeometryDrawing
            {
                Geometry = _currentGeometry,
                Pen = new Pen(Brushes.CadetBlue, 2)
            };

            _drawingGroup.Children.Add(_currentGeometryDrawing);
        }

        private void DrawLineButton_Click(object sender, RoutedEventArgs e)
        {
            _currentGeometry = new LineGeometry();
            _currentGeometryDrawing = new GeometryDrawing
            {
                Geometry = _currentGeometry,
                Pen = new Pen(Brushes.Brown, 2)
            };

            _drawingGroup.Children.Add(_currentGeometryDrawing);
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_currentGeometry != null)
            {
                _startPoint = e.GetPosition(DrawingCanvas);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _currentGeometry != null)
            {
                var pos = e.GetPosition(DrawingCanvas);

                if (_currentGeometry is RectangleGeometry rect)
                {
                    var width = Math.Abs(pos.X - _startPoint.X);
                    var height = Math.Abs(pos.Y - _startPoint.Y);

                    rect.Rect = new Rect(
                        Math.Min(_startPoint.X, pos.X),
                        Math.Min(_startPoint.Y,pos.Y),
                        width,
                        height
                    );
                }
                else if (_currentGeometry is EllipseGeometry ellipse)
                {
                    var width = Math.Abs(pos.X - _startPoint.X);
                    var height = Math.Abs(pos.Y - _startPoint.Y);

                    ellipse.Center = new Point((_startPoint.X + pos.X) / 2, (_startPoint.Y + pos.Y) / 2);
                    ellipse.RadiusX = width / 2;
                    ellipse.RadiusY = height / 2;
                }
                else if (_currentGeometry is LineGeometry line)
                {
                    line.StartPoint = _startPoint;
                    line.EndPoint = pos;
                }
            }
        }
    }
}