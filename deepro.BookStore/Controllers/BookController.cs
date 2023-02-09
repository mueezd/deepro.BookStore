using deepro.BookStore.Models;
using deepro.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace deepro.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository  _bookRepository = null;
        public BookController()
        {
            _bookRepository= new BookRepository();
        }   
        public ViewResult GetAllBooks()
        {
            var data =  _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetails")]
        public ViewResult GetBook(int id)
        {
            dynamic data = new ExpandoObject();
            data.book = _bookRepository.GetBookById(id);
            data.Name = "Deepro";
            //var data =  
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName, string aothorName)
        {
            return _bookRepository.SearchBook(bookName, aothorName);
        }


        public ViewResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {
            return View();
        }
    }
}
