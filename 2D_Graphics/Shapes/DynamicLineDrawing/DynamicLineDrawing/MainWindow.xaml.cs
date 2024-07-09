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

namespace DynamicLineDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Line currentLine;
        private bool isDrawing;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point startPoint = e.GetPosition(DrawingCanvas);

            currentLine = new Line
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = startPoint.X,
                Y2 = startPoint.Y

            };

            DrawingCanvas.Children.Add(currentLine);
            isDrawing = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                currentLine.X2 = currentPoint.X;
                currentLine.Y2 = currentPoint.Y;
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                Point endPoint = e.GetPosition(DrawingCanvas);
                currentLine.X2 = endPoint.X;
                currentLine.Y2 = endPoint.Y;
                isDrawing = false;
            }
        }
    }
}