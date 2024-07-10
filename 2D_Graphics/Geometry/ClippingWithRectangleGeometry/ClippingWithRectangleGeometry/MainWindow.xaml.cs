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

namespace ClippingWithRectangleGeometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateClipping();
        }

        private void UpdateClipping()
        {
            double width;
            double height;
            double xpos;
            double ypos;

            if (double.TryParse(WidthTextBox.Text, out width) &&
                double.TryParse(HeightTextBox.Text, out height) &&
                double.TryParse(XPositionTextBox.Text, out xpos) &&
                double.TryParse(YPositionTextBox.Text,out ypos))
            {
                RectangleGeometry rect = new RectangleGeometry(new Rect(xpos, ypos, width, height));

                ClippedImage.Clip = rect;
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for width, height, X position, and Y position.");
            }
        }
        

        private void UpdateClippingButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateClipping();
        }
    }
}