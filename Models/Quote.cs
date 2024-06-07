
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
        public Pet? pet { get; set; }
        [Required]
        public int VetId { get; set; }
        public Vet? vet { get; set; }
        [Required]
        public string Description { get; set; }
    }
}