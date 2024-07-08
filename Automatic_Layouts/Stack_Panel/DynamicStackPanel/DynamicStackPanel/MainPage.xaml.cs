using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamicStackPanel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int clickCounter = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnAddButton_Click(object sender, RoutedEventArgs e)
        {
            clickCounter++;

            Button btnAddButton = new Button
            {
                Content = $"Button {clickCounter}",
                Width = 200,
                Height = 40,
                CornerRadius = new CornerRadius(5),
                Background = new SolidColorBrush(Colors.Brown),
                Foreground = new SolidColorBrush(Colors.White),
                Margin = new Thickness(5),
            };

            MainStack.Children.Add(btnAddButton);
        }

        private void btnAddTextBlock_Click(object sender, RoutedEventArgs e)
        {
            clickCounter++;

            TextBlock txtBlk = new TextBlock
            {
                Text = $"TextBlock {clickCounter}",
                Width= 200,
                Height = 40,
                TextAlignment = TextAlignment.Left,
                Margin = new Thickness(5),
            };

            MainStack.Children.Add(txtBlk);
        }
    }
}
