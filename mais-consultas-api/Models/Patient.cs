using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public virtual Appointment Appointment { get; set; }

        //Constructor
        public Patient(string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password)
        {
            SetCpf(cpf);
            SetName(name);
            SetPhoneNumber(phoneNumber);
            SetBirthdayDate(birthdayDate);
            SetEmail(email);
            SetPassword(password);
        }

        public void SetId(int id) =>
            Id = id <= 0
                ? throw new ArgumentException("Id n�o pode ser menor ou igual zero")
                : id;

        public void SetCpf(string cpf) =>
           Cpf = string.IsNullOrWhiteSpace(cpf)
               ? throw new ArgumentException("Cpf n�o pode ser nulo")
               : cpf;

        public void SetName(string name) =>
            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException("Nome n�o pode ser nulo")
                : name;

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("N�mero de n�o pode ser nulo");

            PhoneNumber = phoneNumber.Length switch
            {
                > 13 =>
                    throw new ArgumentException("N�mero de telefone n�o ter mais de 15 digitos."),
                < 13 =>
                    throw new ArgumentException("N�mero de telefone n�o ter menos de 15 digitos."),
                _ => phoneNumber
            };
        }

        public void SetBirthdayDate(DateTime birthdayDate)
        {
            if (birthdayDate == DateTime.MinValue)
            {
                throw new ArgumentException("Data de nascimento n�o pode ser nula");
            }
            else
            {
                BirthdayDate = birthdayDate;
            }
        }

        public void SetEmail(string email) =>
            Email = string.IsNullOrWhiteSpace(email)
                ? throw new ArgumentException("Email n�o pode ser nulo")
                : email;

        public void SetPassword(string password) =>
            Password = string.IsNullOrWhiteSpace(password)
                ? throw new ArgumentException("Senha n�o pode ser nula")
                : password;
    }
}
