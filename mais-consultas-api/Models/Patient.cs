using System.ComponentModel.DataAnnotations;

namespace mais_consultas_api.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime BirthdayDate { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        //Constructor
        public Patient()
        {
        }
    }
}