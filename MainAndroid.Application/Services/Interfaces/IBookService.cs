using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAndroid.Application.DTO;

namespace MainAndroid.Application.Services.Interfaces
{
    public interface IBookService
    {
        public BookDTO CreateBook(BookDTO bookDTO);
        public List<BookDTO> GetAllBooks();
        public List<BookDTO> GetBook(int id);
        public bool DeletePerson(int id);
        public bool PutPerson(int id, BookDTO bookDTO);
    }
}
