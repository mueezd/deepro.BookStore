using Microsoft.EntityFrameworkCore;

namespace deepro.BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<language> Languages { get; set; }
        public DbSet<BookGallery> BookGallery { get; set; }



    }
}
