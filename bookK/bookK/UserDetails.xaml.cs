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
    /// Interaction logic for UserDetails.xaml
    /// </summary>
    public partial class UserDetails : Page
    {

        private BookingController Bctr = new BookingController();

        public UserDetails(Model.Classes.User user)
        {
            InitializeComponent();
            FillViewList(user.UserID);
            lblLib.Content = "Bibl Nr.: " + user.UserID;
            lblName.Content = "Navn: " + user.UserName;
        }

        public void FillViewList(int id)
        {
            BookingList.ItemsSource = Bctr.GetAllBookingsByUserID(id);
        }
    }
}
