using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LineAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartAnimation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AnimateLine()
        {
            DoubleAnimation x1Animation = new DoubleAnimation
            {
                From = 50,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };

            DoubleAnimation y1Animation = new DoubleAnimation
            {
                From = 50,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };

            DoubleAnimation x2Animation = new DoubleAnimation
            {
                From = 50,
                To = 500,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };

            DoubleAnimation y2Animation = new DoubleAnimation
            {
                From = 50,
                To = 100,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };

            AnimatedLine.BeginAnimation(Line.X1Property, x1Animation);
            AnimatedLine.BeginAnimation(Line.Y1Property, y1Animation);  
            AnimatedLine.BeginAnimation(Line.X2Property, x2Animation);  
            AnimatedLine.BeginAnimation(Line.Y2Property, y2Animation);

        }
    }
}