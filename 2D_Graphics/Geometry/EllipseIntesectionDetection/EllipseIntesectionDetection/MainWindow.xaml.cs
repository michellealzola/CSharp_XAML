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

namespace EllipseIntesectionDetection
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

        private void CreateEllipsesButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            double width1;
            double height1;
            double centerx1;
            double centery1;

            double width2;
            double height2;
            double centerx2;
            double centery2;

            if (double.TryParse(Width1TextBox.Text, out width1) &&
                double.TryParse(Height1TextBox.Text,out height1) &&
                double.TryParse(CenterX1TextBox.Text, out  centerx1) &&
                double.TryParse(CenterY1TextBox.Text, out centery1) &&
                double.TryParse(Width2TextBox.Text, out width2) &&
                double.TryParse(Height2TextBox.Text, out height2) &&
                double.TryParse(CenterX2TextBox.Text, out centerx2) &&
                double.TryParse(CenterY2TextBox.Text, out centery2))
            {
                EllipseGeometry ellipse1 = new EllipseGeometry(new Point(centerx1, centery1), width1 * 0.5, height1 * .5 );

                Path ellipse1Path = new Path
                {
                    Data = ellipse1,
                    Fill = Brushes.CadetBlue,
                };

                DrawingCanvas.Children.Add(ellipse1Path);

                EllipseGeometry ellipse2 = new EllipseGeometry(new Point(centerx2, centery2), width2 * 0.5, height2 * .5);

                Path ellipse2Path = new Path
                {
                    Data= ellipse2,
                    Fill = Brushes.CornflowerBlue,
                };

                DrawingCanvas.Children.Add(ellipse2Path);

                CombinedGeometry combinedEllipses = new CombinedGeometry(GeometryCombineMode.Intersect, ellipse1, ellipse2);
                
                if (!combinedEllipses.Bounds.IsEmpty)
                {
                    Path intersectionPath = new Path
                    {
                        Data = combinedEllipses,
                        Fill = Brushes.Brown,
                        Stroke = Brushes.Orange,
                        StrokeThickness = 2
                    };

                    DrawingCanvas.Children.Add(intersectionPath);
                }               

            }
            else
            {
                MessageBox.Show("Please enter valid values");
            }
        }
    }
}