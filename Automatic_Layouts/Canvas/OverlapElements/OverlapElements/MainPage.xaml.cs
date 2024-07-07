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
using Windows.UI;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OverlapElements
{
    /*Overlap Elements:
     * Create a Canvas with multiple overlapping shapes of 
     * different colors and opacities. 
     * Experiment with the ZIndex to change their stacking order.
     */
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_AddCircle_Click(object sender, RoutedEventArgs e)
        {
            var randColor = new Random();
            var randZIndex = new Random();

            int numColor = randColor.Next(0, 3);
            int numZIndex = randZIndex.Next(0, 3);
            double opacity = 0;
            var colorValue = Colors.White;

            if (numColor == 0)
            {
                colorValue = Colors.Red;
                opacity = .75;
            }
            else if (numColor == 1)
            {
                colorValue = Colors.Green;
                opacity = .5;
            }
            else if(numColor == 2)
            {
                colorValue = Colors.MediumPurple;
                opacity = .25;
            }

            Ellipse circle = new Ellipse
            {
                Width = 100,
                Height = 100,
                Fill = new SolidColorBrush(colorValue),
                Opacity = opacity,
                
            };

            Canvas.SetZIndex(circle, numZIndex);

            var rand = new Random();

            Canvas.SetLeft(circle, rand.NextDouble() * (Main_Canvas.ActualWidth - circle.Width));
            Canvas.SetTop(circle, rand.NextDouble() * (Main_Canvas.ActualHeight - circle.Height));

            Main_Canvas.Children.Add(circle);

        }
    }
}
