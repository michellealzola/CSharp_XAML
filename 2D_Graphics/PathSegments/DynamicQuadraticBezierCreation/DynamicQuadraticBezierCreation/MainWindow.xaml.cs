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

namespace DynamicQuadraticBezierCreation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PathFigure currentPathFigure;
        private PathGeometry currentPathGeometry;
        private QuadraticBezierSegment quadraticBezierSegment;
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

                    quadraticBezierSegment = new QuadraticBezierSegment();
                   
                    currentPathFigure.Segments.Add(quadraticBezierSegment);
                    currentPathGeometry.Figures.Add(currentPathFigure);

                    path = new Path
                    {
                        Data = currentPathGeometry,
                        Stroke = Brushes.Black,
                        StrokeThickness = 2,
                    };

                    DrawingCanvas.Children.Add(path);

                    break;

                case 1:
                    quadraticBezierSegment.Point1 = clickPoint;
                    
                    break;

                case 2:
                    quadraticBezierSegment.Point2 = clickPoint;
                    clickCount = -1;
                    break;

            }
            clickCount++;
        }
    }
}