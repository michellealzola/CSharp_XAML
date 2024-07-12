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

namespace DynamicBezierSegmentCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PathFigure currentPathFigure;
        private PathGeometry currentPathGeometry;
        private BezierSegment bezierSegment;
        private Path path;
        private int clickCount;

        public MainWindow()
        {
            InitializeComponent();
            clickCount = 0;
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(DrawingCanvas);
            

            switch (clickCount)
            {
                case 0:
                    

                    currentPathGeometry = new PathGeometry();
                    currentPathFigure = new PathFigure
                    {
                        StartPoint = clickPoint,
                    };

                    bezierSegment = new BezierSegment();
                    currentPathFigure.Segments.Add(bezierSegment);
                    currentPathGeometry.Figures.Add(currentPathFigure);

                    path = new Path
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                        Data = currentPathGeometry
                    };
                    

                    DrawingCanvas.Children.Add(path);

                    break;

                case 1:
                    bezierSegment.Point1 = clickPoint;
                    break;

                case 2:
                    bezierSegment.Point2 = clickPoint;
                    break;

                case 3:
                    bezierSegment.Point3 = clickPoint;

                    clickCount = -1;

                    break;
            }

            clickCount++;
        }
    }
}