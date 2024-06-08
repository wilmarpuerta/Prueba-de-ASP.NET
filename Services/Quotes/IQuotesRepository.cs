
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Quotes
{
    public interface IQuotesRepository
    {
        IEnumerable<Quote> GetQuotes();
        IEnumerable<Quote> GetQuotesByDate(DateOnly date);
        IEnumerable<Quote> GetQuotesByVet(int id);
        Quote GetQuote(int id);
        Task<Quote> CreateQuote(Quote quote);
        void UpdateQuote(int id, Quote quote);
    }
}