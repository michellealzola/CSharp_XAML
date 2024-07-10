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

namespace Stroke_Dash_Array
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Polyline? polyline = null;
        public MainWindow()
        {
            InitializeComponent();
            CreatePolyline();
        }

        private void CreatePolyline()
        {
            polyline = new Polyline
            {
                Points = new PointCollection
                {
                    new Point(50, 100),
                    new Point(150, 50),
                    new Point(250, 100),
                    new Point(350, 50),                    
                },
                Stroke = Brushes.Black,
                StrokeThickness = 5,
            };

            DrawingCanvas.Children.Add(polyline);
        }

        private void StrokeDashComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (polyline == null)
            {
                return;
            }

            switch (StrokeDashComboBox.SelectedIndex)
            {
                case 0:
                    polyline.StrokeDashArray = null;
                    break;
                case 1:
                    polyline.StrokeDashArray = new DoubleCollection { 4, 2 };
                    break;
                case 2:
                    polyline.StrokeDashArray = new DoubleCollection { 1, 2 };
                    break;
                case 3:
                    polyline.StrokeDashArray = new DoubleCollection { 4, 2, 1, 2 };
                    break;
            }
        }
    }
}