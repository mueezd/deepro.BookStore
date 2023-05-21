using deepro.BookStore.Data;
using deepro.BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deepro.BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreDbContext _context = null;
        public LanguageRepository(BookStoreDbContext context)
        {
            _context = context;
        }


        public async Task<List<languageModel>> getLanguages()
        {
            return await _context.Languages.Select(x => new languageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();

        }
    }
}
