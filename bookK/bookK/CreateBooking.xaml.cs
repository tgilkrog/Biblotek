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
    /// Interaction logic for CreateBooking.xaml
    /// </summary>
    public partial class CreateBooking : Page
    {
        private BookingController Bctr = new BookingController();

        public CreateBooking()
        {
            InitializeComponent();
            FillViewList();
        }

        public void FillViewList()
        {
            UserList.ItemsSource = Bctr.GetAllUsers();
            BookList.ItemsSource = Bctr.GetAvailableBooks();
        }

        private void NewBooking(object sender, RoutedEventArgs e)
        {
            Bctr.CreateBooking((Model.Classes.User)UserList.SelectedItem, (Model.Classes.Book)BookList.SelectedItem);
            FillViewList();
        }
    }
}
