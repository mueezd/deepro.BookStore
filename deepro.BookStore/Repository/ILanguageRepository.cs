using deepro.BookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deepro.BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<languageModel>> getLanguages();
    }
}