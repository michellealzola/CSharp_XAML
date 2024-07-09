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

            UpdateArrowhead(StartArrowhead, start, end, true);
            UpdateArrowhead(EndArrowhead, end, start, true);
        }

        private void UpdateArrowhead(Polygon arrowhead, Point start, Point end, bool isStart)
        {
            Vector direction = start - end;
            direction.Normalize();
            direction *= arrowheadSize;

            Point arrowPoint1 = start + new Vector(-direction.Y, direction.X) / 2;
            Point arrowPoint2 = end + new Vector(direction.X,-direction.Y) / 2;

            arrowhead.Points = new PointCollection
            {
                start,
                arrowPoint1,
                arrowPoint2
            };
        }
    }
}