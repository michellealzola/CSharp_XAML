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

namespace Basic_Drawing_Shapes
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

        private void DrawShapes()
        {
            DrawingGroup drawingGroup = new DrawingGroup();

            RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(50,50,100,100));
            GeometryDrawing rectangleDrawing = new GeometryDrawing
            {
                Geometry = rectangleGeometry,
                Brush = Brushes.CadetBlue,
                Pen = new Pen(Brushes.Black, 2)
            };

            drawingGroup.Children.Add(rectangleDrawing);

            EllipseGeometry ellipseGeometry = new EllipseGeometry(new Point(200, 200), 50, 75);
            GeometryDrawing ellipseDrawing = new GeometryDrawing
            {
                Geometry = ellipseGeometry,
                Brush = Brushes.Coral,
                Pen = new Pen(Brushes.Black, 2)
            };

            drawingGroup.Children.Add(ellipseDrawing);

            LineGeometry lineGeometry = new LineGeometry(new Point(300,100), new Point(400,300));
            GeometryDrawing lineDrawing = new GeometryDrawing
            {
                Geometry = lineGeometry,
                Brush = Brushes.Brown,
                Pen = new Pen(Brushes.Black, 2)
            };

            drawingGroup.Children.Add(lineDrawing);

            DrawingImage drawingImage = new DrawingImage(drawingGroup);

            Image imageControl = new Image
            {
                Source = drawingImage,
                Stretch = Stretch.None,
            };

            DrawingCanvas.Children.Add(imageControl);
        }
    }
}