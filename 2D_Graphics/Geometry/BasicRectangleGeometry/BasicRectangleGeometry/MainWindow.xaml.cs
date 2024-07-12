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

namespace BasicRectangleGeometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateRectangleGeometry();
        }

        private void CreateRectangleGeometry()
        {
            double xCoordinate = 50;
            double yCoordinate = 50;
            double width = 150;
            double height = 100;

            RectangleGeometry rectGeometry = new RectangleGeometry(new Rect(xCoordinate, yCoordinate, width, height));

            Path path = new Path
            {
                Stroke = Brushes.CadetBlue,
                StrokeThickness = 2,
                Fill = Brushes.Coral,
                Data = rectGeometry
            };

            DrawingCanvas.Children.Add(path);
        }
    }
}