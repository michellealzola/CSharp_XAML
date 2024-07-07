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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InteractiveCanvas
{
    /*Interactive Canvas:
    Create a Canvas with a Button and a TextBlock.
    When the button is clicked, move the TextBlock to a new position on the canvas.*/
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Move_Click(object sender, RoutedEventArgs e)
        {
            double xPos = GenerateRandomMovement(Main_Canvas.ActualWidth - Textblock_Moving.ActualWidth);
            double yPos = GenerateRandomMovement(Main_Canvas.ActualHeight - Textblock_Moving.ActualHeight);

            Canvas.SetLeft(Textblock_Moving, xPos);
            Canvas.SetTop(Textblock_Moving, yPos);  
        }

        private double GenerateRandomMovement(double maxPos)
        {
            var random = new Random();

            return random.NextDouble() * maxPos;
        }
    }
}
