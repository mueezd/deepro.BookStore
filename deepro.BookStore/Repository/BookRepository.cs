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
                Language= model.Language,
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
                        Language = book.Language,
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
                    Language = book.Language,
                    Title = book.Title,
                    TotalPage = book.TotalPage
                };
                return bookDetails;

            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "MVC", Author = "Nitesh", Description = "This Is Desceription of MVC Book", Category="Programming 1", Language="English", TotalPage = 1050},
                new BookModel() { Id = 2, Title = "C#", Author = "Monika", Description = "This Is Desceription of C# Book", Category="Programming 2", Language="English + Bangla", TotalPage = 231 },
                new BookModel() { Id = 3, Title = "Java", Author = "deepro", Description = "This Is Desceription of Java Book", Category="Programming 3", Language="English + Urdhu", TotalPage = 3041 },
                new BookModel() { Id = 4, Title = "PHP", Author = "pritha", Description = "This Is Desceription of PHP Book", Category="Programming 4", Language="English + Hindi", TotalPage = 4323 },
                new BookModel() { Id = 5, Title = "Python", Author = "zakir", Description = "This Is Desceription of Python Book", Category="Programming 5", Language="English + Bangla", TotalPage = 7962 }
            };

        }

    }
}
