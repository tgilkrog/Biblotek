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
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        BookController Bctr = new BookController();

        public Book()
        {
            InitializeComponent();
            FillViewList();
        }

        public void FillViewList()
        {
            //BookList.ItemsSource = Bctr.GetAllBooks();
            TvBox.ItemsSource = Bctr.GetAllBooks();
        }

        private void CreateBook(object sender, RoutedEventArgs e)
        {
            Bctr.CreateBook(txtTitle.Text, txtAuthor.Text, txtIsbn.Text, txtPic.Text);
            txtTitle.Clear();
            txtAuthor.Clear();
            txtIsbn.Clear();
            txtPic.Clear();
            FillViewList();
        }
    }
}
