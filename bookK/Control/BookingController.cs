using Model;
using Model.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class BookingController
    {
        private BookingDataAccess Bda = new BookingDataAccess();
        private UserController Uctr = new UserController();
        private BookController Bctr = new BookController();

        //Denne metode opretter en list af bookings alt efter om det skal være med ledige bøger, eller bøger som er retuneret.
        public List<Booking> GetList(bool ReturnBool)
        {
            List<Booking> BookedBooks = new List<Booking>();

            foreach (var item in Bda.GetAllBookings())
            {
                if (ReturnBool == false)
                {
                    if (item.Returned == false)
                    {
                        BookedBooks.Add(item);
                    }
                }

                else if (ReturnBool == true) { 

                if(item.Returned == true)
                    {
                        BookedBooks.Add(item);
                    }
                }
            }
            return BookedBooks;
        }

        //Her kaldes Usercontroller til at hente brugere som skal bruges til booking
        public List<User> GetAllUsers()
        {
            return Uctr.GetAllUsers();
        }

        //her kaldes BookController til at hente bøgerne
        public  List<Book> GetAllBooks()
        {
            return Bctr.GetAllBooks();
        }

        public List<Booking> GetAllBookingsByUserID(int id)
        {
            return Bda.GetBookingsByUserID(id);
        }

        //Her henter den de bøger som ikke er lejet ud
        public List<Book> GetAvailableBooks()
        {
            return Bctr.GetAvailableBooks();
        }

        //MEtoden til at oprette en udlejning, hvor der skal bruges en bruger og en bog
        public void CreateBooking(User user, Book book)
        {
            Booking booking = new Booking
            {
                User = user,
                Book = book,
                Returned = false
            };

            //Her ændre den bogens status til at være udlejet
            Bctr.SetAvailableFalse(book);
            //her sendes den oprettede booking til databasen.
            Bda.CreateBooking(booking);
        }

        //Her returneres en bog, ved at ændre booking return til true, og den ændre bogens status til at være ledig
        public void ReturnBook(Booking booking)
        {
            Bctr.SetAvailableTrue(booking.Book);
            booking.Returned = true;
            Bda.UpdateBooking(booking);
        }


        //Herunder er to metoder som bruges til test, så de ikke skrev i databasen.
        public Booking CreateBookingTest(User user, Book book)
        {
            Booking booking = new Booking
            {
                User = user,
                Book = book,
                Returned = false
            };

            return booking;
        }

        public Booking ReturnBookTest(Booking booking)
        {
            booking.Returned = true;
            return booking;
        }
    }
}
