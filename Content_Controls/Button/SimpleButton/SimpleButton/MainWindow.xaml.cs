using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeButton();
        }

        private void InitializeButton()
        {
            Button btnClickMe = new Button
            {
                Content = "Click Me",
                Width = 100,
                Height = 50,

            };

            btnClickMe.Click += btnClickMe_Click;

            MainGrid.Children.Add(btnClickMe);

        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked!");
        }

    }
}