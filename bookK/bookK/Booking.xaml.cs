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
    public partial class Booking : Page
    {
        private BookingController Bctr = new BookingController();

        public Booking()
        {
            InitializeComponent();
            FillViewList();
        }

        public void FillViewList()
        {
            BookingList.ItemsSource = Bctr.GetList(false);
            ReturnedList.ItemsSource = Bctr.GetList(true);
        }

        private void UpdateBooking(object sender, RoutedEventArgs e)
        {
            Bctr.ReturnBook((Model.Classes.Booking)BookingList.SelectedItem);
            FillViewList();
        }
    }
}
