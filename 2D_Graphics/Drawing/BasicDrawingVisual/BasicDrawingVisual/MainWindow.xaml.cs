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

namespace BasicDrawingVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawShapes();
        }

        private void AddVisualToCanvas(DrawingVisual visual)
        {
            var hostVisual = new HostVisual(visual);
            DrawingCanvas.Children.Add(hostVisual);
        }

        private void DrawShapes()
        {
            var drawingVisual = new DrawingVisual();

            using(var drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawRectangle(Brushes.CadetBlue, new Pen(Brushes.Black, 2), new Rect(50, 50, 200, 100));
                drawingContext.DrawEllipse(Brushes.White, new Pen(Brushes.Black, 2), new Point(400, 150), 100, 50);
                drawingContext.DrawLine(new Pen(Brushes.Coral, 2), new Point(100, 300), new Point(500, 300));

            }

            AddVisualToCanvas(drawingVisual);
        }


    }
}