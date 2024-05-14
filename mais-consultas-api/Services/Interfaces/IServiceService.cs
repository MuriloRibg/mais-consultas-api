using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Constructor
        public Service()
        {
        }
    }
}
