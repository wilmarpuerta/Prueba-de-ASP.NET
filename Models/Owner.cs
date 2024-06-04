
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prueba_de_ASP.NET.Models
{
    public class Owner
    {
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [JsonIgnore]
        public List<Pet>? Pets { get; set; }
        
    }
}