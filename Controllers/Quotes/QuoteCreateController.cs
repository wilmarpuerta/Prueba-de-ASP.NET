
using Prueba_de_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Services.Quotes;

namespace Prueba_de_ASP.NET.Controllers.Quotes
{
    [ApiController]
    [Route("api/quotes")]
    public class QuoteCreateController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public QuoteCreateController(QuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            try
            {
                _quotesRepository.CreateQuote(quote);
                return Ok("Quote created successfully");

            }
            catch
            {
                return BadRequest("Error creating quote");
            }
        }
    }
}