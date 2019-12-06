using Model;
using Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class BookController
    {
        private BookDataAccess Bda = new BookDataAccess();

        //metode til at hente alle bøger der er i databasen
        public List<Book> GetAllBooks()
        {
            return Bda.GetAllBooks();
        }

        public List<Book> GetAvailableBooks()
        {
            return Bda.GetAvailableBook();
        }

        //Her oprettes en bog med tre parametre title, author og isbn nr.
        public void CreateBook(string title, string author, string isbn)
        {
            Book book = new Book
            {
                Title = title,
                Author = author,
                ISBN = Convert.ToInt32(isbn),
                Available = true
            };
            Bda.CreateBook(book);
        }

        //Herunder er der to metoder til at gøre en bog ledig eller optaget
        public void SetAvailableFalse(Book book)
        {
            book.Available = false;
            Bda.UpdateBook(book);
        }

        public void SetAvailableTrue(Book book)
        {
            book.Available = true;
            Bda.UpdateBook(book);
        }
    }
}
