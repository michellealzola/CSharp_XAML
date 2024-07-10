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

namespace DynamicLineCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private LineGeometry currentlineGeometry;
        private Path currentlinePath;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!isDrawing)
            {
                Point startPoint = e.GetPosition(DrawingCanvas);
                currentlineGeometry = new LineGeometry
                {
                    StartPoint = startPoint,
                    EndPoint = startPoint
                };

                currentlinePath = new Path
                {
                    Data = currentlineGeometry,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                DrawingCanvas.Children.Add(currentlinePath);
                isDrawing = true;
            }
        }

        private void DrawingCanvas_MouseMOve(object sender, MouseEventArgs e)
        {
            if(isDrawing && currentlineGeometry != null)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                currentlineGeometry.EndPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(isDrawing)
            {
                isDrawing = false;
                currentlineGeometry = null;
                currentlinePath = null;

            }
        }
    }
}