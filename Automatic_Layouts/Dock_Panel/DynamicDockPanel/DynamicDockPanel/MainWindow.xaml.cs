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

namespace DynamicDockPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int clickCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_AddMenu_Click(object sender, RoutedEventArgs e)
        {
            clickCounter++;

            Button btn = new Button
            {
                Content = $"Menu {clickCounter}",
                Width = 150 ,
                Height = 30,
                Margin = new Thickness(5),
                Background = new SolidColorBrush(Colors.BurlyWood),
                Foreground = new SolidColorBrush (Colors.White),
            };

            Menu.Children.Add(btn);

        }
    }
}