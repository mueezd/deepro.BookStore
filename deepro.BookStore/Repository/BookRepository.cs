using deepro.BookStore.Data;
using deepro.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace deepro.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreDbContext _context = null;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPage = model.TotalPage.HasValue ? model.TotalPage.Value: 0,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await  _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbook = await _context.Books.ToListAsync();
            if (allbook?.Any() == true)
            {
                foreach (var book in allbook)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        Title = book.Title,
                        TotalPage = book.TotalPage
                    });
                }
            }
            return books;
        }


        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Title = book.Title,
                    TotalPage = book.TotalPage
                };
                return bookDetails;

            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

    }
}
