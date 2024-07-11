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

namespace BasicLineSegment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddLineSegment();
        }

        private void AddLineSegment()
        {
            Path myPath = new Path
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            PathGeometry myPathGeometry = new PathGeometry();

            PathFigureCollection myPathFigureCollection = new PathFigureCollection();

            PathFigure myPathFigure = new PathFigure
            {
                StartPoint = new Point(10, 50),
            };

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();

            LineSegment myLineSegment = new LineSegment
            {
                Point = new Point(200, 50),
                IsStroked = true,
            };

            myPathSegmentCollection.Add(myLineSegment);

            myPathFigure.Segments = myPathSegmentCollection;    

            myPathFigureCollection.Add(myPathFigure);

            myPathGeometry.Figures = myPathFigureCollection;

            myPath.Data = myPathGeometry;

            DrawingCanvas.Children.Add(myPath);


            
        }
    }
}