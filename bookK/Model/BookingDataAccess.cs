using Model.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookingDataAccess
    {
        static string connectionString = "Server=TG; Initial Catalog=bookK; Integrated Security=true";

        public List<Booking> GetAllBookings()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From [dbo].[Booking] as r, [dbo].[bookKUser] as bu, [dbo].[Book] as b WHERE r.userId = bu.id AND r.bookId = b.id", connection);
                connection.Open();
                var reader = cmd.ExecuteReader();

                List<Booking> bookings = new List<Booking>();

                while (reader.Read())
                {
                    bookings.Add(new Booking()
                    {
                        BookingID = reader.GetInt32(0),
                        User = new User
                        {
                            UserID = reader.GetInt32(4),
                            UserName = reader.GetString(5)
                        },
                        Book = new Book
                        {
                            BookID = reader.GetInt32(6),
                            Title = reader.GetString(7),
                            Author = reader.GetString(8),
                            ISBN = reader.GetInt32(9),
                            Available = reader.GetBoolean(10)
                        },
                        Returned = reader.GetBoolean(3)
                    });
                }
                return bookings;
            };
        }

        public void CreateBooking(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into [dbo].[Booking](userId, bookId, returned) values(@userId, @bookId, @returned)";
                    cmd.Parameters.AddWithValue("userId", booking.User.UserID);
                    cmd.Parameters.AddWithValue("bookId", booking.Book.BookID);
                    cmd.Parameters.AddWithValue("returned", booking.Returned);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBooking(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update Booking SET returned = @returned WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", booking.BookingID);
                    cmd.Parameters.AddWithValue("returned", booking.Returned);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
