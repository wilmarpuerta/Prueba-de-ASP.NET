
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.DTOs;
using Prueba_de_ASP.NET.Services.Quotes;

namespace Prueba_de_ASP.NET.Controllers.Quotes
{
    [ApiController]
    [Route("api/quotes")]
    public class QuoteUpdateController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        public QuoteUpdateController(IQuotesRepository quotesRepository)
        {
            _quotesRepository = quotesRepository;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] QuoteDto quote)
        {
            try
            {
                _quotesRepository.UpdateQuote(id, quote);
                return Ok("Quote updated successfully");
            }
            catch
            {
                return BadRequest("Quote update failed");
            }
        }
    }
}