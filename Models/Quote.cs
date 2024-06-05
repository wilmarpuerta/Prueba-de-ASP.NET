
using System.ComponentModel.DataAnnotations;

namespace Prueba_de_ASP.NET.Models
{
    public class Quote
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int PetId { get; set; }
        [Required]
        public int VetId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}