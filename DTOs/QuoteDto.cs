
namespace Prueba_de_ASP.NET.DTOs
{
    public class QuoteDto
    {
        public int? Id { get; set; }
        public DateOnly? Date { get; set; }
        public int? PetId { get; set; }
        public int? VetId { get; set; }
        public string? Description { get; set; }
    }
}