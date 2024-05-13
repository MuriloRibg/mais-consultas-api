using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "date")]
        public DateTime BirthdayDate { get; set; }

        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        //Constructor
        public Patient(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password)
        {
            SetId(id);
            SetCpf(cpf);
            SetName(name);
            SetPhoneNumber(phoneNumber);
            SetBirthdayDate(birthdayDate);
            SetEmail(email);
            SetPassword(password);
        }

        public void SetId(int id) =>
            Id = id <= 0
                ? throw new ArgumentException("Id não pode ser menor ou igual zero")
                : id;

        public void SetCpf(string cpf) =>
           Cpf = string.IsNullOrWhiteSpace(cpf)
               ? throw new ArgumentException("Cpf não pode ser nulo")
               : cpf;

        public void SetName(string name) =>
            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException("Nome não pode ser nulo")
                : name;

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Número de não pode ser nulo");

            PhoneNumber = phoneNumber.Length switch
            {
                > 15 =>
                    throw new ArgumentException("Número de telefone não ter mais de 15 digitos."),
                < 15 =>
                    throw new ArgumentException("Número de telefone não ter menos de 15 digitos."),
                _ => phoneNumber
            };
        }


        public void SetBirthdayDate(DateTime birthdayDate)
        {
            if (birthdayDate == DateTime.MinValue)
            {
                throw new ArgumentException("Data de nascimento não pode ser nula");
            }
            else
            {
                BirthdayDate = birthdayDate;
            }
        }

        public void SetEmail(string email) =>
            Email = string.IsNullOrWhiteSpace(email)
                ? throw new ArgumentException("Email não pode ser nulo")
                : email;

        public void SetPassword(string password) =>
            Password = string.IsNullOrWhiteSpace(password)
                ? throw new ArgumentException("Senha não pode ser nula")
                : password;




    }
}