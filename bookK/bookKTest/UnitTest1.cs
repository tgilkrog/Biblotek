using System;
using Control;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Classes;

namespace bookKTest
{
    [TestClass]
    public class UnitTest1
    {
        BookingController Bctr = new BookingController();

        [TestMethod]
        public void TestBooking()
        {
            //Her gør jeg det lidt nemt for mig selv og opretter en bruger og bog med ID 1, da jeg ved disse eksistere i databasen.
            User user = new User
            {
                UserID = 1
            };
            Book book = new Book
            {
                BookID = 1
            };

            Booking booking = Bctr.CreateBookingTest(user, book);

            Assert.AreEqual(booking.Returned, false);
        }

        [TestMethod]
        public void TestReturn()
        {
            //Her gør jeg det lidt nemt for mig selv og opretter en bruger og bog med ID 1, da jeg ved disse eksistere i databasen.
            User user = new User
            {
                UserID = 1
            };
            Book book = new Book
            {
                BookID = 1
            };

            Booking booking = Bctr.CreateBookingTest(user, book);
            Bctr.ReturnBook(booking);

            Assert.AreEqual(booking.Returned, true);
        }
    }
}
