
namespace Prueba_de_ASP.NET.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public int VetId { get; set; }
        public string Description { get; set; }
    }
}