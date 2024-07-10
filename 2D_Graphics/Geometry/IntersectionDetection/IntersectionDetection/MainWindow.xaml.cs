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

namespace IntersectionDetection
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

        private void DrawRectanglesButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();

            double width1;
            double height1;
            double xpos1;
            double ypos1;

            double width2;
            double height2;
            double xpos2;
            double ypos2;

            if (double.TryParse(Width1TextBox.Text, out width1) &&
                double.TryParse(Height1TextBox.Text, out height1) &&
                double.TryParse(XPos1TextBox.Text, out xpos1) &&
                double.TryParse(YPos1TextBox.Text, out ypos1) &&
                double.TryParse(Width2TextBox.Text,out width2) &&
                double.TryParse(Height2TextBox.Text, out height2) &&
                double.TryParse(XPos2TextBox.Text, out xpos2) &&
                double.TryParse(YPos2TextBox.Text, out ypos2))
            {
                RectangleGeometry rect1 = new RectangleGeometry(new Rect(xpos1, ypos1, width1, height1));
                Path rect1Path = new Path
                {
                    Data = rect1,
                    Stroke = Brushes.Brown,
                    StrokeThickness = 2
                };

                RectangleGeometry rect2 = new RectangleGeometry(new Rect(xpos2, ypos2, width2, height2));
                Path rect2Path = new Path
                {
                    Data = rect2,
                    Stroke = Brushes.CadetBlue,
                    StrokeThickness = 2
                };

                DrawingCanvas.Children.Add(rect1Path);
                DrawingCanvas.Children.Add(rect2Path);

                Rect intersection = Rect.Intersect(new Rect(xpos1, ypos1, width1, height1), new Rect(xpos2, ypos2, width2, height2));

                if (intersection != Rect.Empty)
                {
                    RectangleGeometry intersectionRect = new RectangleGeometry(intersection);
                    Path intersectionPath = new Path
                    {
                        Data= intersectionRect,
                        Stroke = Brushes.Blue,
                        StrokeThickness = 2,
                        Fill = Brushes.LightBlue,
                    };

                    DrawingCanvas.Children.Add(intersectionPath);

                }
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values for all dimensions and positions.");
            }
        }
    }
}