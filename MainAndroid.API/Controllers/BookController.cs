using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MainAndroid.Application.DTO;
using MainAndroid.Application.Services.Interfaces;
using System.Collections.Generic;
using MainAndroid.Domain.Book;
using System.IO;

namespace MainAndroid.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public List<BookDTO> AllBook()
        {
            var result = _bookService.GetAllBooks();
            return result;
        }
        [HttpGet("{name}/{author}/{description}/{price}/{publisher}/{year}/{pages}/{img_url}")]
        public BookDTO CreateBook(string name, string author, string description, string price, string publisher,
                                    string year, string pages, string img_url)
        {
            BookDTO bookDTO = new BookDTO()
            {
                id = 0,
                name = name,
                author = author,
                description = description,
                price = price,
                publisher = publisher,
                year = year,
                pages = pages,
                img_url = img_url
            };
            var result = _bookService.CreateBook(bookDTO);
            return result;
        }
        [HttpPost("CreateBook1")]
        public bool CreateBook1(BookDTO bookDTO)
        {
            var result = _bookService.CreateBook(bookDTO);
            if (result is BookDTO)
            {
                return true;
            }
            else 
                return false;
        }
        [HttpGet("{id}")]
        public List<BookDTO> GetBook(int id)
        {
            return _bookService.GetBook(id);
        }
        [HttpGet("{id}/{name}/{author}/{description}/{price}/{publisher}/{year}/{pages}/{img_url}")]
        public bool ChangeBook(int id, string name, string author, string description, string price, string publisher,
                                    string year, string pages, string img_url)
        {
            BookDTO bookDTO = new BookDTO()
            {
                id = 0,
                name = name,
                author = author,
                description = description,
                price = price,
                publisher = publisher,
                year = year,
                pages = pages,
                img_url = img_url
            };
            return _bookService.PutPerson(id, bookDTO);
        }
        [HttpPost("post/{id}")]
        public bool ChangeBook1(int id, BookDTO bookDTO)
        {
            return _bookService.PutPerson(id, bookDTO);
        }
        [HttpGet("del/{id}")]
        public bool DeleteBook(int id)
        {
            return _bookService.DeletePerson(id);
        }
        
    }
}
