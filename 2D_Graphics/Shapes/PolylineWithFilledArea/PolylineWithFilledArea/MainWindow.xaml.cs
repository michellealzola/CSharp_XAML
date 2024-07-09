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

namespace PolylineWithFilledArea
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline currentPolyline;
        private Polygon filledPolygon;
        private bool isFilled;
        public MainWindow()
        {
            InitializeComponent();
            InitializeDRawingObjects();
        }

        private void InitializeDRawingObjects()
        {
            currentPolyline = new Polyline
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(currentPolyline);

            filledPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.LightBlue,
                Visibility = Visibility.Collapsed
            };

            DrawingCanvas.Children.Add(filledPolygon);

        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(DrawingCanvas);
            currentPolyline.Points.Add(clickPosition);
            filledPolygon.Points.Add(clickPosition); ;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
            InitializeDRawingObjects ();
        }

        private void ToggleFillButton_Click(object sender, RoutedEventArgs e)
        {
            if (isFilled)
            {
                currentPolyline.Visibility = Visibility.Visible;
                filledPolygon.Visibility = Visibility.Collapsed;
            }
            else
            {
                currentPolyline.Visibility= Visibility.Collapsed;
                filledPolygon.Visibility= Visibility.Visible;
            }

            isFilled = !isFilled;
        }
    }
}