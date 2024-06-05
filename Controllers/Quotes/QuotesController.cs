
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Services.Quotes;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Controllers.Quotes
{
    [ApiController]
    [Route("api/quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public QuotesController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpGet]
        public IEnumerable<Quote> GetQuotes()
        {
            try
            {
                return _quotesRepository.GetQuotes();
            }
            catch
            {
                return (IEnumerable<Quote>)BadRequest("Error getting owners");
            }
        }

        [HttpGet("{id}")]
        public Quote GetQuoteById(int id)
        {
            var Quote = _quotesRepository.GetQuote(id);
            if(!ModelState.IsValid)
            {
                NotFound("Quote not found");
            }
            
            return Quote;
        }
    }
}