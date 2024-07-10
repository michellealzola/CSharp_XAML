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
        EllipseGeometry ellipse;
        Path ellipsePath;
        public MainWindow()
        {
            InitializeComponent();
            CreateEllipse();
        }

        private void CreateEllipse()
        {
            ellipse = new EllipseGeometry(new Point(100, 150), 100, 100);

            ellipsePath = new Path
            {
                Data = ellipse,
                Fill = Brushes.Brown,
            };

            DrawingCanvas.Children.Add(ellipsePath);

        }

        private void AnimateButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard storyboard = new Storyboard();

            DoubleAnimation xAnim = new DoubleAnimation
            {
                From = 0,
                To = 300,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
            };

            Storyboard.SetTarget(xAnim, ellipsePath);
            Storyboard.SetTargetProperty(xAnim, new PropertyPath("(Canvas.Left)"));

            DoubleAnimation yAnim = new DoubleAnimation
            {
                From = 0,
                To = 100,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
            };

            Storyboard.SetTarget(yAnim, ellipsePath);
            Storyboard.SetTargetProperty(yAnim, new PropertyPath("(Canvas.Top)"));

            storyboard.Children.Add(xAnim);
            storyboard.Children.Add(yAnim);

            storyboard.Begin();

        }
    }
}