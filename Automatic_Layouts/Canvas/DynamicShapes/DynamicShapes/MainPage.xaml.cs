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
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamicShapes
{
    /*Dynamic Shapes:
     * Create a Canvas that dynamically adds shapes 
     * (like Rectangle and Ellipse) at random positions when a button is clicked.
     */
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_AddCircle_Click(object sender, RoutedEventArgs e)
        {
            var circleShape = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = new SolidColorBrush(Colors.Red),

            };

            var random = new Random();

            Canvas.SetLeft(circleShape, random.NextDouble() * (Main_Canvas.ActualWidth - circleShape.Width));
            Canvas.SetTop(circleShape, random.NextDouble() * (Main_Canvas.ActualHeight - circleShape.Height));

            Main_Canvas.Children.Add(circleShape);

        }
    }
}
