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

namespace LineCaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Line line;
        public MainWindow()
        {
            InitializeComponent();
            DrawLine();
        }

        private void DrawLine()
        {
            line = new Line
            {
                X1 = 100,
                Y1 = 100,
                X2 = 350,
                Y2 = 100,
                Stroke = Brushes.Black,
                StrokeThickness = 10,
                StrokeStartLineCap = PenLineCap.Flat,
                StrokeEndLineCap = PenLineCap.Flat,
            };

            DrawingCanvas.Children.Add(line);
        }

        private void StartLineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (line == null)
            {
                return;
            }

            switch (StartLineCapComboBox.SelectedIndex)
            {
                case 0:
                    line.StrokeStartLineCap = PenLineCap.Flat; 
                    break;
                case 1:
                    line.StrokeStartLineCap = PenLineCap.Square;
                    break;
                case 2:
                    line.StrokeStartLineCap = PenLineCap.Round;
                    break;
                case 3:
                    line.StrokeStartLineCap = PenLineCap.Triangle;
                    break;
            }
        }

        private void EndLineComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (line == null)
            {
                return;
            }

            switch (EndLineCapComboBox.SelectedIndex)
            {
                case 0:
                    line.StrokeEndLineCap = PenLineCap.Flat;
                    break;
                case 1:
                    line.StrokeEndLineCap = PenLineCap.Square;
                    break;
                case 2:
                    line.StrokeEndLineCap = PenLineCap.Round;
                    break;
                case 3:
                    line.StrokeEndLineCap = PenLineCap.Triangle;
                    break;
            }
        }
    }
}