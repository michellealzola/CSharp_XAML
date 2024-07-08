using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DraggingShapes2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool isDragging = false;
        private Shape draggedShape = null;
        private Point offset;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Shape_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            draggedShape = sender as Shape;
            isDragging = true;
            offset = e.GetCurrentPoint(Main_Canvas).Position;
            offset.X -= Canvas.GetLeft(draggedShape);
            offset.Y -= Canvas.GetTop(draggedShape);
            draggedShape.CapturePointer(e.Pointer);
        }

        private void Shape_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (isDragging && draggedShape != null)
            {
                Point position = e.GetCurrentPoint(Main_Canvas).Position;
                Canvas.SetLeft(draggedShape, position.X - offset.X);
                Canvas.SetTop(draggedShape, position.Y - offset.Y);
            }

        }

        private void Shape_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            isDragging = false;
            if(draggedShape != null)
            {
                draggedShape.ReleasePointerCaptures();
                draggedShape = null;    
            }
        }
    }
}
