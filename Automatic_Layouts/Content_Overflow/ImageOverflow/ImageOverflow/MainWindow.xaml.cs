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

namespace ImageOverflow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            addImageToWrap();
        }

        public void addImageToWrap()
        {
            string imagePath = "pack://application:,,,/Images/my_logo.png";

            for (int i = 0; i < 20; i++)
            {
                Image image = new Image
                {
                    Width = 100, 
                    Height = 100,
                    Margin = new Thickness(5),
                };

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();
                image.Source = bitmap;
                ImageWrapper.Children.Add(image);
            }

        }
    }
}