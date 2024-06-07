
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prueba_de_ASP.NET.Models
{
    public class Vet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [JsonIgnore]
        public List<Quote>? quotes { get; set; }
    }
}