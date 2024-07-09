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

namespace EllipseAnimation
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation horizontalAnimation = new DoubleAnimation
            {
                From = 10,
                To = MainCanvas.ActualWidth - AnimatedEllipse.Width - 10,
                Duration = new Duration(TimeSpan.FromSeconds(5)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
            };

            DoubleAnimation verticalAnimation = new DoubleAnimation
            {
                From = 10,
                To = MainCanvas.ActualHeight - AnimatedEllipse.Height - 10,
                Duration = new Duration(TimeSpan.FromSeconds(5)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(horizontalAnimation);
            storyboard.Children.Add(verticalAnimation);

            Storyboard.SetTarget(horizontalAnimation, AnimatedEllipse);
            Storyboard.SetTargetProperty(horizontalAnimation, new PropertyPath("(Canvas.Left)"));

            Storyboard.SetTarget(verticalAnimation, AnimatedEllipse);
            Storyboard.SetTargetProperty(verticalAnimation, new PropertyPath("(Canvas.Top)"));

            storyboard.Begin();
        }
    }
}