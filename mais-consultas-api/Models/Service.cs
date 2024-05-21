using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mais_consultas_api.Models
{
    public class Service
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [JsonIgnore]
        public Professional Professional { get; set; }

        // Constructor
        public Service()
        {
        }
    }
}
