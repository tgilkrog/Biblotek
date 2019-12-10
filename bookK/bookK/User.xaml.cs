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
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Page
    {
        UserController Uctr = new UserController();

        public User()
        {
            InitializeComponent();
            FillViewList();
        }

        public void FillViewList()
        {
            UserList.ItemsSource = Uctr.GetAllUsers();
        }


        private void CreateUser(object sender, RoutedEventArgs e)
        {
            Uctr.CreateUser(txtName.Text);

            txtName.Clear();
            FillViewList();
        }

        private void UserDetails_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mw != null)
                mw.Main.Content = new UserDetails((Model.Classes.User)UserList.SelectedItem);
        }
    }
}
