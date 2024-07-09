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

namespace LineWithArrowheads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double arrowheadSize = 10;

        public MainWindow()
        {
            InitializeComponent();
            UpdateArrowheads();
        }

        private void ArrowheadSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            arrowheadSize = e.NewValue;
            UpdateArrowheads();
        }

        private void UpdateArrowheads_Click(object sender, RoutedEventArgs e)
        {
            UpdateArrowheads();
        }

        private void UpdateArrowheads()
        {
            Point start = new Point(MainLine.X1, MainLine.Y1);
            Point end = new Point(MainLine.X2, MainLine.Y2);

            UpdateArrowhead(StartArrowhead, start, end);
            UpdateArrowhead(EndArrowhead, end, start);
        }

        private void UpdateArrowhead(Polygon arrowhead, Point start, Point end)
        {
            Vector direction = end - start;
            direction.Normalize();
            Vector perpendicular = new Vector(-direction.Y, direction.X);

            Point arrowBase1 = end - direction * arrowheadSize + perpendicular * (arrowheadSize / 2);
            Point arrowBase2 = end - direction * arrowheadSize - perpendicular * (arrowheadSize / 2);

            arrowhead.Points = new PointCollection
            {
                end,
                arrowBase1,
                arrowBase2
            };
        }
    }
}