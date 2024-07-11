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

namespace BasicLineSegment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawingCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(DrawingCanvas);

            lineSegment.Point = mousePosition;

            PathGeometry pathGeometry = path.Data as PathGeometry;

            if (pathGeometry != null && pathGeometry.Figures.Count > 0)
            {
                PathFigure pathFigure = pathGeometry.Figures[0];
                pathFigure.StartPoint = new Point(100, 100);
            }
        }
    }
}