using deepro.BookStore.Models;
using deepro.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace deepro.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository  _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository= bookRepository;
        }   

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }


        [Route("book-details/{id}", Name = "bookDetails")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }
        public List<BookModel> SearchBooks(string bookName, string aothorName)
        {
            return _bookRepository.SearchBook(bookName, aothorName);
        }


        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            //var model = new BookModel()
            //{
            //    Language= "English"
            //};


            ViewBag.language = new List<string>()
            {
                "English",
                "Banhla",
                "Hindi",
                "Spanish",
                "French"
            };

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.language = new List<string>()
            {
                "English",
                "Banhla",
                "Hindi",
                "Spanish",
                "French"
            };


            ViewBag.IsSuccess = false;
            ViewBag.BookId = 0;

            //ModelState.AddModelError("", "This is my customer error message");
            return View();
        }
    }
}
