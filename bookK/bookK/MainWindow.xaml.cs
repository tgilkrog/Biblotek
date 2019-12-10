using Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bookK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserController uctr = new UserController();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TopGrid_MouseDown(object sender, RoutedEventArgs e)
        {
            DragMove();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new User();
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Book();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Booking();
        }

        private void NewBooking_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateBooking();
        }
    }
}
