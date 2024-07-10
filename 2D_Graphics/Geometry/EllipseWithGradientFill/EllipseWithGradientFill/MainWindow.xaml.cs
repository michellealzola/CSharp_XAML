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

namespace EllipseWithGradientFill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GradientStop gradient1;
        private GradientStop gradient2;

        public MainWindow()
        {
            InitializeComponent();
            CreateEllipse();
        }

        private void CreateEllipse()
        {
            EllipseGeometry ellipse = new EllipseGeometry(new Point(200, 200), 150, 150);

            gradient1 = new GradientStop(Colors.CadetBlue, 0);
            gradient2 = new GradientStop(Colors.Coral, 1);

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(gradient1);
            gradientBrush.GradientStops.Add(gradient2);

            Path ellipsePath = new Path
            {
                Data = ellipse,
                Fill = gradientBrush,               
            };

            DrawingCanvas.Children.Add(ellipsePath);
        }

        private void Gradient1_SelectedColorCHanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
            {
                gradient1.Color = e.NewValue.Value;
            }
        }

        private void Gradient2_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
            {
                gradient2.Color = e.NewValue.Value;
            }
        }

        private void Gradient1Offset_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gradient1.Offset = e.NewValue;
        }

        private void Gradient2Offset_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gradient2.Offset = e.NewValue;
        }
    }
}