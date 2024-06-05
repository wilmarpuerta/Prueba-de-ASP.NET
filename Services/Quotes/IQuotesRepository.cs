
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Quotes
{
    public interface IQuotesRepository
    {
        IEnumerable<Quote> GetQuotes();
        Quote GetQuote(int id);
        void CreateQuote(Quote quote);
        void UpdateQuote(int id, Quote quote);
    }
}