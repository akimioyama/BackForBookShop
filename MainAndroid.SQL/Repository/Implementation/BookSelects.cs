using MainAndroid.Domain.Book;
using MainAndroid.SQL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MainAndroid.SQL.Repository.Implementation
{
    public class BookSelects : IBookSelects
    {
        string stringconn = $"Data Source=LAPTOP-FPR118VN\\SQLEXPRESS;" +
            $"Initial Catalog=androidApp;Integrated Security=True;" +
            $"Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            $"ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool CreateBook(Book book)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"insert into Books VALUES ('{book.name}', '{book.author}', '{book.description}', " +
                    $"'{book.price}', '{book.publisher}', '{book.year}', '{book.pages}', '{book.img_url}')";
                var command = new SqlCommand(sql, conn);
                int eee = command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteBook(int id)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"delete from Books where Books.id = {id}";
                var command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Book> GetAllBook()
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"SELECT * FROM [androidApp].[dbo].[Books]";
                var command = new SqlCommand(sql, conn);
                var books = new List<Book>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var temp = new Book();
                        temp.id = (int)reader.GetInt32(0);
                        temp.name = reader.GetString(1).ToString();
                        temp.author = reader.GetString(2).ToString();
                        temp.description = reader.GetString(3).ToString();
                        temp.price = reader.GetString(4).ToString();
                        temp.publisher = reader.GetString(5).ToString();
                        temp.year = reader.GetString(6).ToString();
                        temp.pages = reader.GetString(7).ToString();
                        temp.img_url = reader.GetString(8).ToString();
                        books.Add(temp);
                    }
                }
                return books;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Book> GetBook(int id)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"select * from Books where Books.id = {id}";
                var command = new SqlCommand(sql, conn);
                var books = new List<Book>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var temp = new Book();
                        temp.id = (int)reader.GetInt32(0);
                        temp.name = reader.GetString(1).ToString();
                        temp.author = reader.GetString(2).ToString();
                        temp.description = reader.GetString(3).ToString();
                        temp.price = reader.GetString(4).ToString();
                        temp.publisher = reader.GetString(5).ToString();
                        temp.year = reader.GetString(6).ToString();
                        temp.pages = reader.GetString(7).ToString();
                        temp.img_url = reader.GetString(8).ToString();
                        books.Add(temp);
                    }
                }
                return books;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool UpdateBook(int id, Book book)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"" +
                    $"update Books set " +
                    $"[name] = '{book.name}'," +
                    $"[author] = '{book.author}', " +
                    $"[description] = '{book.description}', " +
                    $"[price] = '{book.price}'," +
                    $"[publisher] = '{book.publisher}'," +
                    $"[year] = '{book.year}', " +
                    $"[pages] = '{book.year}', " +
                    $"[img_url] = '{book.img_url}' where id = {id}";

                var command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
