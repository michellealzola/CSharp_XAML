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

namespace BasicImageDisplay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DisplayImage();
        }

        private void DisplayImage()
        {
            BitmapImage image = new BitmapImage(new Uri("F:\\AdobeIllustrator\\WinterClipart01_ECA\\WinterClipart01_ECA-BonusBackground.jpg", UriKind.Relative));

            ImageDrawing imageDrawing = new ImageDrawing
            {
                ImageSource = image,
                Rect = new Rect(0, 0, image.Width/2, image.Height/2),
            };

            DrawingGroup drawingGroup = new DrawingGroup();
            drawingGroup.Children.Add(imageDrawing);

            DrawingImage drawingImage = new DrawingImage(drawingGroup);

            Image imageControl = new Image
            {
                Source = drawingImage,
                Stretch = Stretch.UniformToFill
            };

            DrawingCanvas.Children.Add(imageControl);
        }
    }
}