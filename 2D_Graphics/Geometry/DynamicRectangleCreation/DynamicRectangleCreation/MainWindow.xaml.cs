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

namespace DynamicRectangleCreation
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

        private void DrawRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            double width;
            double height;
            double xpos;
            double ypos;

            if (double.TryParse(WidthTextBox.Text, out width) &&
                double.TryParse(HeightTextBox.Text,out height) &&
                double.TryParse(XPositinTextBox.Text, out xpos) &&
                double.TryParse(YPositinTextBox.Text, out ypos))
            {
                RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(xpos, ypos, width, height));

                Path rectanglePath = new Path
                {
                    Data = rectangleGeometry,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Blue,

                };

                DrawingCanvas.Children.Add(rectanglePath);
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for width, height, X position, and Y position.");
            }      

            
        }
    }
}