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

namespace DraggingShapes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Shape draggedShape = null;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Shape_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            draggedShape = sender as Shape;
            args.Data.SetText("Shape");
            args.Data.RequestedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;

        }

        private void Main_Canvas_DragEnter(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }

        private void Main_Canvas_Drop(object sender, DragEventArgs e)
        {
            if (draggedShape != null)
            {
                var position = e.GetPosition(Main_Canvas);
                Canvas.SetLeft(draggedShape, position.X - draggedShape.Width / 2);
                Canvas.SetTop(draggedShape, position.Y - draggedShape.Height / 2);
                draggedShape = null;
            }
        }
    }
}
