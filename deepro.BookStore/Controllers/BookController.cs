using deepro.BookStore.Models;
using deepro.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

namespace deepro.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
            var model = new BookModel()
            {
                //Language = "2"
            };




            //ViewBag.language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "ddepero", Value = "1"},
            //    new SelectListItem(){Text = "Bangal", Value = "2"},
            //    new SelectListItem(){Text = "English", Value = "3"},
            //    new SelectListItem(){Text = "Urdu", Value = "4"},
            //    new SelectListItem(){Text = "Hindi", Value = "5"},
            //    new SelectListItem(){Text = "Korean", Value = "6"},
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
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

            ViewBag.language = new SelectList(getLanguage(), "Id", "Text");

            //ViewBag.language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text = "ddepero", Value = "1"},
            //    new SelectListItem(){Text = "Bangal", Value = "2"},
            //    new SelectListItem(){Text = "English", Value = "3"},
            //    new SelectListItem(){Text = "Urdu", Value = "4"},
            //    new SelectListItem(){Text = "Hindi", Value = "5"},
            //    new SelectListItem(){Text = "Korean", Value = "6"},
            //};

            return View(bookModel);
        }

        private List<languageModel> getLanguage()
        {
            return new List<languageModel>()
            {
                new languageModel() {Id = 1, Text = "Hindi"},
                new languageModel() {Id = 2, Text = "English"},
                new languageModel() {Id = 3, Text = "Dutach"},
                new languageModel() {Id = 4, Text = "Bangla"},
            };
        }
    }
}
