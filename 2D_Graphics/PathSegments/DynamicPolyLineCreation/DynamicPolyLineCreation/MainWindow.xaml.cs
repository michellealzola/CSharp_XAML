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

namespace DynamicPolyLineCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PathFigure currentPathFigure;
        private PathGeometry currentPathGeometry;
        private PolyLineSegment polyLineSegment;
        private bool isDrawing;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(DrawingCanvas);

            if (!isDrawing)
            {                

                Path path = new Path
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                };

                currentPathGeometry = new PathGeometry();

                currentPathFigure = new PathFigure
                {
                    StartPoint = clickPoint,
                };

                polyLineSegment = new PolyLineSegment();
                polyLineSegment.Points.Add(clickPoint);
                currentPathFigure.Segments.Add(polyLineSegment);

                currentPathGeometry.Figures.Add(currentPathFigure);

                path.Data = currentPathGeometry;

                DrawingCanvas.Children.Add(path);

                isDrawing = true;
            }
            else
            {
                polyLineSegment.Points.Add(clickPoint);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && polyLineSegment.Points.Count > 0)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);

                polyLineSegment.Points[polyLineSegment.Points.Count - 1] = currentPoint;

                DrawingCanvas.InvalidateVisual();
            }
        }

        private void DrawingCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
            }
        }
    }
}