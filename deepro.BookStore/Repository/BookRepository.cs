using deepro.BookStore.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace deepro.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }


        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id== id).FirstOrDefault();
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
