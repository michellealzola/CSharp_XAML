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

namespace DynamicPolylineDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline currentPolyline = null;
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
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(currentPolyline);
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
            InitializePolyline();
        }

        private void DrawingCanvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(DrawingCanvas);
            currentPolyline.Points.Add(clickPosition);
        }
    }
}