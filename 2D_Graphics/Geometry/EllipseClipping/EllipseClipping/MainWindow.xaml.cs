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

namespace EllipseClipping
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

        private void ClipImageButton_Click(object sender, RoutedEventArgs e)
        {
            double width;
            double height;
            double centerx;
            double centery;

            if (double.TryParse(WidthTextBox.Text, out width) &&
                double.TryParse(HeightTextBox.Text, out height) &&
                double.TryParse(CenterXTextBox.Text, out centerx) &&
                double.TryParse(CenterYTextBox.Text, out centery))
            {
                EllipseGeometry ellipse = new EllipseGeometry(new Point(centerx, centery), width * 0.5, height * 0.5);

                ClippedImage.Clip = ellipse;
            }
            else
            {
                MessageBox.Show("Please enter valid values");
            }
        }
    }
}