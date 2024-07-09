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

namespace ResizableAndDraggableRectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging;
        private bool isResizing;

        private Rectangle selectedRectangle;
        private Point clickPosition;
        public MainWindow()
        {
            InitializeComponent();
            selectedRectangle = DraggableRectangle;
            selectedRectangle.MouseLeftButtonDown += Rectange_MouseLeftButtonDown;
            selectedRectangle.MouseLeftButtonUp += Rectangle_MouseLeftButtonUp;
            selectedRectangle.MouseMove += Rectangle_MouseMove;

        }

       

        private void Rectange_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.DirectlyOver is Rectangle)
            {
                selectedRectangle = (Rectangle)Mouse.DirectlyOver;
                clickPosition = e.GetPosition(MainCanvas);
                isDragging = true;
                selectedRectangle.CaptureMouse();
            }

            if(IsMouseOnCorner(selectedRectangle, e.GetPosition(MainCanvas)))
            {
                isResizing = true;
                isDragging = false;
                selectedRectangle.CaptureMouse();
            }
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(isDragging ||  isResizing)
            {
                isDragging = false;
                isResizing = false;
                selectedRectangle.ReleaseMouseCapture();
            }
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging)
            {
                Point currentPosition = e.GetPosition(MainCanvas);
                double left = Canvas.GetLeft(selectedRectangle) + (currentPosition.X - clickPosition.X);
                double top = Canvas.GetTop(selectedRectangle) + (clickPosition.Y - clickPosition.Y);

                Canvas.SetLeft(selectedRectangle, left);    
                Canvas.SetTop(selectedRectangle, top);
                clickPosition = currentPosition;
            }

            if (isResizing)
            {
                Point currentPosition = e.GetPosition((MainCanvas));
                double newWidth = Math.Max(10, currentPosition.X - Canvas.GetLeft(selectedRectangle));
                double newHeight = Math.Max(10, currentPosition.Y - Canvas.GetTop(selectedRectangle));

                selectedRectangle.Width = newWidth;
                selectedRectangle.Height = newHeight;
            }
        }

        private bool IsMouseOnCorner(Rectangle rectangle, Point mousePosition)
        {
            double left = Canvas.GetLeft(rectangle);
            double top = Canvas.GetTop(rectangle);
            double right = left + rectangle.Width;
            double bottom = top + rectangle.Height;

            return Math.Abs(mousePosition.X - right) < 10 && Math.Abs(mousePosition.Y - bottom) < 10;
        }
    }
}