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

namespace DynamicEllipseCreation
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

        private void CreateEllipseButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            double width;
            double height;
            double centerx;
            double centery;

            if (double.TryParse(WidthTextBox.Text, out width) &&
                double.TryParse(HeightTextBox.Text,out height) &&
                double.TryParse(CenterXTextBox.Text, out centerx) &&
                double.TryParse(CenterYTextBox.Text, out centery))
            {
                EllipseGeometry ellipse = new EllipseGeometry(new Point(centerx, centery), width * 0.5, height * 0.5);

                Path ellipsePath = new Path
                {
                    Data = ellipse,
                    Fill = Brushes.Brown,
                    Stroke = Brushes.Black,
                    StrokeThickness = 2
                };

                DrawingCanvas.Children.Add(ellipsePath);
            }
            else
            {
                MessageBox.Show("Enter valid values");
            }
        }
    }
}