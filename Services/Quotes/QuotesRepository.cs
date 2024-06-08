
using Microsoft.EntityFrameworkCore;
using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Email;
using Prueba_de_ASP.NET.Services.Pets;

namespace Prueba_de_ASP.NET.Services.Quotes
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly BaseContext _baseContext;
        private readonly SendEmail _sendEmail;
        private readonly IPetsRepository _petsRepository;
        public QuotesRepository(BaseContext baseContext, SendEmail sendEmail, IPetsRepository petsRepository)
        {
            _baseContext = baseContext;
            _sendEmail = sendEmail;
            _petsRepository = petsRepository;
        }
        public async Task<Quote> CreateQuote(Quote quote)
        {
            _baseContext.Quotes.Add(quote);
            _baseContext.SaveChanges();

            var pet = _petsRepository.GetPet(quote.PetId);

            var from = "MS_TEpzKI@trial-v69oxl5om7kg785k.mlsender.net";
            var fromName = "Clínica veterinaria";
            var to = new List<string> { pet.Owner.Email };
            var toNames = new List<string> { pet.Owner.Names + " " + pet.Owner.LastNames };
            var subject = "Confirmación de Cita";
            var text = $"Hola { pet.Owner.Names + " " + pet.Owner.LastNames }, tu cita ha sido confirmada para el {quote.Date.ToString("dd/MM/yyyy")}";
            var html = $"<p>Hola { pet.Owner.Names + " " + pet.Owner.LastNames },</p><p>Tu cita ha sido confirmada para el <strong>{quote.Date.ToString("dd/MM/yyyy")}.</p>";

            await _sendEmail.SendEmailAsync(from, fromName, to, toNames, subject, text, html);

            return quote;
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