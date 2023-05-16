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
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in model.Gallary)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbook = await _context.Books.Include(x => x.language).ToListAsync();
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
                        Language = book.language.Name,
                        Title = book.Title,
                        TotalPage = book.TotalPage,
                        CoverImageUrl= book.CoverImageUrl
                    });
                }
            }
            return books;
        }


        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id).
                Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.language.Name,
                    Title = book.Title,
                    TotalPage = book.TotalPage,
                    CoverImageUrl= book.CoverImageUrl,
                    Gallary = book.bookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                    
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

    }
}
