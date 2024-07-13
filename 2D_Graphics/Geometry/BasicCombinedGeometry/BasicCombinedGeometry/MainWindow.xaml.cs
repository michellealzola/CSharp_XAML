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

namespace BasicCombinedGeometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(150, 150, 50, 50));
        EllipseGeometry ellipseGeometry = new EllipseGeometry(new Point(200, 175), 25, 25);

        public MainWindow()
        {
            InitializeComponent();

            Path rectPath = new Path
            {
                Data = rectangleGeometry,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(rectPath);

            Path ellipsePath = new Path
            {
                Data= ellipseGeometry,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };
            DrawingCanvas.Children.Add(ellipsePath);
        }

        private void Union_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Union, rectangleGeometry, ellipseGeometry);

            Path combinedPath = new Path
            {
                Data = combinedGeometry,
                Stroke = Brushes.LightCoral,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.LightCoral),
            };

            DrawingCanvas.Children.Add(combinedPath);
        }

        private void Intersect_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Intersect, rectangleGeometry, ellipseGeometry);

            Path combinedPath = new Path
            {
                Data = combinedGeometry,
                Stroke = Brushes.LightCoral,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.LightCoral),
            };

            DrawingCanvas.Children.Add(combinedPath);
        }

        private void Difference_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Xor, rectangleGeometry, ellipseGeometry);

            Path combinedPath = new Path
            {
                Data = combinedGeometry,
                Stroke = Brushes.LightCoral,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.LightCoral),
            };

            DrawingCanvas.Children.Add(combinedPath);
        }

        private void Exclude_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            CombinedGeometry combinedGeometry = new CombinedGeometry(GeometryCombineMode.Exclude, rectangleGeometry, ellipseGeometry);

            Path combinedPath = new Path
            {
                Data = combinedGeometry,
                Stroke = Brushes.LightCoral,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.LightCoral),
            };

            DrawingCanvas.Children.Add(combinedPath);
        }
    }
}