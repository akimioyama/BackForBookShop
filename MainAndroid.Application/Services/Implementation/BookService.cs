using MainAndroid.Application.DTO;
using MainAndroid.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainAndroid.Application.DTO;
using MainAndroid.SQL.Repository.Implementation;
using MainAndroid.SQL.Repository.Interfaces;
using MainAndroid.Domain.Book;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata.Ecma335;

namespace MainAndroid.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        IConfiguration _configuration;
        IBookSelects bookSelects;
        public BookService(IConfiguration conf)
        {
            _configuration = conf;
            bookSelects = new BookSelects();
        }

        public BookDTO CreateBook(BookDTO bookDTO)
        {
            Book book = new Book()
            {
                id = -1,
                name = bookDTO.name,
                author = bookDTO.author,
                description = bookDTO.description,
                price = bookDTO.price,
                publisher = bookDTO.publisher,
                year = bookDTO.year,
                pages = bookDTO.pages,
                img_url = bookDTO.img_url
            };
            if (bookSelects.CreateBook(book))
                return bookDTO;
            return null;
        }

        public bool DeletePerson(int id)
        {
            return bookSelects.DeleteBook(id);
        }

        public List<BookDTO> GetAllBooks()
        {
            List<Book> bookList = bookSelects.GetAllBook();
            if(bookList != null)
            {
                List<BookDTO> bookDTOs = new List<BookDTO>();
                foreach (Book book in bookList)
                {
                    BookDTO bookDTO = new BookDTO()
                    {
                        id = book.id,
                        name = book.name,
                        author = book.author,
                        description = book.description,
                        price = book.price,
                        publisher = book.publisher,
                        year = book.year,
                        pages = book.pages,
                        img_url = book.img_url
                    };
                    bookDTOs.Add(bookDTO);
                }
                return bookDTOs;
            }
            return null;
        }

        public List<BookDTO> GetBook(int id)
        {
            List<Book> bookList = bookSelects.GetBook(id);
            if (bookList != null)
            {
                List<BookDTO> bookDTOs = new List<BookDTO>();
                foreach (Book book in bookList)
                {
                    BookDTO bookDTO = new BookDTO()
                    {
                        id = book.id,
                        name = book.name,
                        author = book.author,
                        description = book.description,
                        price = book.price,
                        publisher = book.publisher,
                        year = book.year,
                        pages = book.pages,
                        img_url = book.img_url
                    };
                    bookDTOs.Add(bookDTO);
                }
                return bookDTOs;
            }
            return null;
        }

        public bool PutPerson(int id, BookDTO bookDTO)
        {
            Book book = new Book()
            {
                id = id,
                name = bookDTO.name,
                author = bookDTO.author,
                description = bookDTO.description,
                price = bookDTO.price,
                publisher = bookDTO.publisher,
                year = bookDTO.year,
                pages = bookDTO.pages,
                img_url = bookDTO.img_url
            };
            return bookSelects.UpdateBook(id, book);
        }
    }
}
