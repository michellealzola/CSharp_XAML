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

namespace CombinedGeometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateGeometries();
        }

        private void CreateGeometries()
        {
            RectangleGeometry rect = new RectangleGeometry(new Rect(50,50,100,100));
            EllipseGeometry ellipse = new EllipseGeometry(new Point(200, 200), 50, 50);

            GeometryGroup combinedGeometry = new GeometryGroup();
            combinedGeometry.Children.Add(rect);    
            combinedGeometry.Children.Add(ellipse);

            Path combinedPath = new Path
            {
                Data = combinedGeometry,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(combinedPath);
        }
    }
}