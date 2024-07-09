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

namespace DynamicPolygonDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polygon currentPolygon;
        public MainWindow()
        {
            InitializeComponent();
            InitializePolygon();
        }

        private void InitializePolygon()
        {
            currentPolygon = new Polygon
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                Fill = Brushes.Brown,
            };

            DrawingCanvas.Children.Add(currentPolygon);

        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(DrawingCanvas);
            currentPolygon.Points.Add(clickPosition);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
            InitializePolygon();
        }

        private void ClosePolygonButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPolygon.Points.Count > 2)
            {
                currentPolygon.Points.Add(currentPolygon.Points[0]);
            }
        }
    }
}