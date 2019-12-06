using Model.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookDataAccess
    {
        static string connectionString = "Server=TG; Initial Catalog=bookK; Integrated Security=true";

        public List<Book> GetAllBooks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * From [dbo].[Book]", connection);
                connection.Open();
                var reader = cmd.ExecuteReader();

                List<Book> books = new List<Book>();

                while (reader.Read())
                {
                    books.Add(new Book()
                    {
                        BookID = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        ISBN = reader.GetInt32(3)

                    });
                }
                return books;
            };
        }

        public List<Book> GetAvailableBook()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * FROM [dbo].[Book] WHERE available = 1", connection);
                connection.Open();
                var reader = cmd.ExecuteReader();

                List<Book> books = new List<Book>();

                while (reader.Read())
                {
                    books.Add(new Book()
                    {
                        BookID = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        ISBN = reader.GetInt32(3)

                    });
                }
                return books;
            };
        }

        public void CreateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Insert Into [dbo].[Book](title, author, isbn, available) values(@title, @author, @isbn, @available)";
                    cmd.Parameters.AddWithValue("title", book.Title);
                    cmd.Parameters.AddWithValue("author", book.Author);
                    cmd.Parameters.AddWithValue("isbn", book.ISBN);
                    cmd.Parameters.AddWithValue("available", book.Available);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBook(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "Update Book SET available = @available WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", book.BookID);
                    cmd.Parameters.AddWithValue("available", book.Available);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
