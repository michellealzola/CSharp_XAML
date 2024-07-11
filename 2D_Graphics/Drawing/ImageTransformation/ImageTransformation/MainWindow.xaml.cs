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

namespace ImageTransformation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageDrawing _imageDrawing;
        private DrawingGroup _drawingGroup;
        private DrawingImage _drawingImage;
        private Image _imageControl;

        public MainWindow()
        {
            InitializeComponent();
            InitializeImage();
        }

        private void InitializeImage()
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri("F:\\AdobeIllustrator\\WinterClipart01_ECA\\WinterClipart01_ECA-BonusBackground.jpg", UriKind.Relative));

            // Create an ImageDrawing
            _imageDrawing = new ImageDrawing
            {
                ImageSource = bitmapImage,
                Rect = new Rect(0, 0, bitmapImage.PixelWidth, bitmapImage.PixelHeight)
            };

            // Create a DrawingGroup and add the ImageDrawing
            _drawingGroup = new DrawingGroup();
            _drawingGroup.Children.Add(_imageDrawing);

            // Create a DrawingImage from the DrawingGroup
            _drawingImage = new DrawingImage(_drawingGroup);

            // Create an Image control to display the DrawingImage
            _imageControl = new Image
            {
                Source = _drawingImage,
                Stretch = Stretch.None
            };

            // Add the Image control to the Canvas
            DrawingCanvas.Children.Add(_imageControl);
        }

        private void Transform_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_drawingGroup != null)
            {
                // Create a TransformGroup to hold all transformations
                TransformGroup transformGroup = new TransformGroup();

                // Add ScaleTransform
                ScaleTransform scaleTransform = new ScaleTransform(ScaleXSlider.Value, ScaleYSlider.Value);
                transformGroup.Children.Add(scaleTransform);

                // Add RotateTransform
                RotateTransform rotateTransform = new RotateTransform(RotateSlider.Value);
                transformGroup.Children.Add(rotateTransform);

                // Add TranslateTransform
                TranslateTransform translateTransform = new TranslateTransform(TranslateXSlider.Value, TranslateYSlider.Value);
                _imageControl.RenderTransform = translateTransform;
                transformGroup.Children.Add(translateTransform);

                // Apply the TransformGroup to the DrawingGroup
                _drawingGroup.Transform = transformGroup;
            }
        }
    }
}