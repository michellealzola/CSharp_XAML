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

namespace LineStyleCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush lineColor;
        private double lineThickness;
        private DoubleCollection lineDashPattern;
        public MainWindow()
        {
            InitializeComponent();

            lineColor = Brushes.Black;
            lineThickness = 2;
            lineDashPattern = null;
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
            {
                lineColor = new SolidColorBrush(e.NewValue.Value);
            }
        }

        private void ThicknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lineThickness = e.NewValue; 
        }

        private void DashPatternComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)DashPatternComboBox.SelectedItem;

            switch (selectedItem.Content.ToString())
            {
                case "Solid":
                    lineDashPattern = null;
                    break;
                case "Dash":
                    lineDashPattern = new DoubleCollection { 4, 2 };
                    break;
                case "Dot":
                    lineDashPattern = new DoubleCollection { 1, 2 };
                    break;
                case "Dash-Dot":
                    lineDashPattern = new DoubleCollection { 4, 2, 1, 2 };
                    break;
                case "Dash-Dot-Dot":
                    lineDashPattern = new DoubleCollection { 4, 2, 1, 2, 1, 2 };
                    break;
            }
        }

        private void DrawLineButton_Click(object sender, RoutedEventArgs e)
        {
            
            Line line = new Line
            {
                Stroke = lineColor,
                StrokeThickness = lineThickness,
                X1 = 150,
                Y1 = 50,
                X2 = 650,
                Y2 = 350,
                StrokeDashArray = lineDashPattern,
            
            };

            DrawingCanvas.Children.Add(line);
        }
    }
}