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

namespace RectangleAnimation
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

        private void AnimateButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation xAnimation = new DoubleAnimation
            { 
                From = 0,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
            };

            Storyboard.SetTarget(xAnimation, AnimatedRectangle);
            Storyboard.SetTargetProperty(xAnimation, new PropertyPath("(Canvas.Left)"));

            DoubleAnimation yAnimation = new DoubleAnimation
            {
                From = 0,
                To = 200,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
            };

            Storyboard.SetTarget(yAnimation, AnimatedRectangle);
            Storyboard.SetTargetProperty(yAnimation, new PropertyPath("(Canvas.Top)"));

            storyboard.Children.Add(xAnimation);
            storyboard.Children.Add(yAnimation);

            storyboard.Begin();
        }
    }
}