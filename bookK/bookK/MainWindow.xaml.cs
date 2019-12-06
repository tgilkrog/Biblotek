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
            FillViewList();
        }

        public void FillViewList()
        {
         
        }

        private void GoToUser(object sender, RoutedEventArgs e)
        {
            Main.Content = new User();
        }

        private void GoToBooks(object sender, RoutedEventArgs e)
        {
            Main.Content = new Book();
        }

        private void GoToBooking(object sender, RoutedEventArgs e)
        {
            Main.Content = new Booking();
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
