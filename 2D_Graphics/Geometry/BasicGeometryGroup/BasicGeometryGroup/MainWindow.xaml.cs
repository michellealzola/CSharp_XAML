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

namespace BasicGeometryGroup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateGeometryGroup();
        }

        private void CreateGeometryGroup()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            geometryGroup.Children.Add(new RectangleGeometry(new Rect(10, 150, 50, 50)));
            geometryGroup.Children.Add(new EllipseGeometry(new Point(80, 175), 25, 25));

            Path path = new Path
            {
                Data = geometryGroup,
                Stroke = Brushes.Black, 
                StrokeThickness = 2,
            };

            DrawingCanvas.Children.Add(path);

        }
    }
}