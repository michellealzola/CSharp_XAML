﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicResizingRectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(ResizableRectangle != null)
            {
                ResizableRectangle.Width = e.NewValue;
            }
        }

        private void HeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ResizableRectangle != null)
            {
                ResizableRectangle.Height = e.NewValue;
            }
        }

        private void CornerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ResizableRectangle != null)
            {
                ResizableRectangle.RadiusX = e.NewValue;
                ResizableRectangle.RadiusY = e.NewValue;
            }
        }
    }
}