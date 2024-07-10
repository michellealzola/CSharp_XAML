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

namespace RectangleWithRoundedCorners
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RectangleGeometry rect;
        public MainWindow()
        {
            InitializeComponent();
            DrawRectangle();
        }

        private void DrawRectangle()
        {
            double width = 100;
            double height = 100;
            double xpos = 50;
            double ypos = 50;

            rect = new RectangleGeometry(new Rect(xpos, ypos, width, height));

            Path rectPath = new Path
            {
                Data = rect,
                Fill = Brushes.Brown,
            };

            DrawingCanvas.Children.Add(rectPath);
        }

        private void RadiusSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rect == null)
            {
                return;
            }

            rect.RadiusX = e.NewValue;
            rect.RadiusY = e.NewValue;  
        }
    }
}