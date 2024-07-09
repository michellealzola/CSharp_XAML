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

namespace Ellipse_Gradient_Fill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GradientStop gradientsStop1;
        private GradientStop gradientsStop2;
        public MainWindow()
        {
            InitializeComponent();

            gradientsStop1 = new GradientStop(Colors.CadetBlue, 0);
            gradientsStop2 = new GradientStop(Colors.Coral, 1);

            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.GradientStops.Add(gradientsStop1);
            gradientBrush.GradientStops.Add(gradientsStop2);

            GradientEllipse.Fill = gradientBrush;
        }

        private void ColorPicker1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if(e.NewValue.HasValue)
            {
                gradientsStop1.Color = e.NewValue.Value;
            }
        }

        private void OffsetSlider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gradientsStop1.Offset = e.NewValue;
        }

        private void ColorPicker2_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if(e.NewValue.HasValue)
            {
                gradientsStop2.Color = e.NewValue.Value;
            }
        }

        private void OffsetSlider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            gradientsStop2.Offset = e.NewValue;
        }
    }
}