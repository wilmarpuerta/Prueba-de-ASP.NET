
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Prueba_de_ASP.NET.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specie { get; set; }
        [Required]
        public string Race { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
        [Required]
        public string Photo { get; set; }
        
    }
}