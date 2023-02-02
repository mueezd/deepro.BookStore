using deepro.BookStore.Models;
using deepro.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public ViewResult GetBook(int id)
        {

            var data =  _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string aothorName)
        {
            return _bookRepository.SearchBook(bookName, aothorName);
        }
    }
}
