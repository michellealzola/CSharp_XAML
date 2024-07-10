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

namespace StrokeLineJoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Rectangle rectangle;
        public MainWindow()
        {
            InitializeComponent();
            DrawRectangle();
        }

        private void DrawRectangle()
        {
            rectangle = new Rectangle
            {
                Width = 200,
                Height = 100,
                Stroke = Brushes.Black,
                StrokeThickness = 10,
                StrokeLineJoin = PenLineJoin.Miter,
                Margin = new Thickness(5)
            };

            DrawingCanvas.Children.Add(rectangle);

        }

        private void LineJoinComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rectangle == null) 
            {
                return;
            }

            switch (LineJoinComboBox.SelectedIndex)
            {
                case 0:
                    rectangle.StrokeLineJoin = PenLineJoin.Miter;
                    break;
                case 1:
                    rectangle.StrokeLineJoin = PenLineJoin.Bevel;
                    break;
                case 2:
                    rectangle.StrokeLineJoin = PenLineJoin.Round;
                    break;
            }
        }
    }
}