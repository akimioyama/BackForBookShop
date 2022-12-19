using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAndroid.Domain.Book;

namespace MainAndroid.SQL.Repository.Interfaces
{
    public interface IBookSelects
    {
        public bool CreateBook(Book book);
        public bool DeleteBook(int id);
        public List<Book> GetBook(int id);
        public List<Book> GetAllBook();
        public bool UpdateBook(int id, Book book);
    }
}
