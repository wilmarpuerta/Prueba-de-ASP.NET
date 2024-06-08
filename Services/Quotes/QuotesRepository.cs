

using Microsoft.EntityFrameworkCore;
using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly BaseContext _baseContext;
        public QuotesRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public void CreateQuote(Quote quote)
        {
            _baseContext.Quotes.Add(quote);
            _baseContext.SaveChanges();
        }

        public Quote GetQuote(int id)
        {
            var quote = _baseContext.Quotes.Include(p => p.Pet).Include(v => v.Vet).FirstOrDefault(q => q.Id == id);
            return quote;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            var quotes = _baseContext.Quotes.Include(p => p.Pet).Include(v => v.Vet).ToList();
            return quotes;
        }

        public IEnumerable<Quote> GetQuotesByDate(DateOnly date)
        {
            var quotesDate = _baseContext.Quotes.Where(q => q.Date == date).ToList();
            return quotesDate;
        }

        public IEnumerable<Quote> GetQuotesByVet(int id)
        {
            var quotesVet = _baseContext.Quotes.Where(q => q.VetId == id).Include(v => v.Vet).ToList();
            return quotesVet;
        }

        public void UpdateQuote(int id, Quote quote)
        {
            var quoteUpdate = _baseContext.Quotes.FirstOrDefault(q => q.Id == id);
            quoteUpdate.Date = quote.Date;
            quoteUpdate.PetId = quote.PetId;
            quoteUpdate.VetId = quote.VetId;
            quoteUpdate.Description = quote.Description;

            _baseContext.SaveChanges();
        }
    }
}