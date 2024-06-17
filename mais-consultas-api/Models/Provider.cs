using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace mais_consultas_api.Models
{
    public class Provider
    {
        [Key] public int Id { get; protected set; }

        [Required] [MaxLength(45)] public string Name { get; protected set; }

        [Required] [MaxLength(45)] public string Cnpj { get; protected set; }

        [Required] [MaxLength(15)] public string PhoneNumber { get; protected set; }

        [Required] [MaxLength(45)] public string Email { get; protected set; }

        [ForeignKey("Address")] public int Id_Address { get; set; }
        public Address Address { get; set; }

        [JsonIgnore] public Professional Professional { get; set; }
        [JsonIgnore] public Appointment Appointment { get; set; }

        public Provider()
        {
        }

        public Provider(int id, string name, string cnpj, string phoneNumber, string email)
        {
            SetId(id);
            SetName(name);
            SetCnpj(cnpj);
            SetPhoneNumber(phoneNumber);
            SetEmail(email);
        }

        public void SetId(int id) =>
            Id = id <= 0
                ? throw new ArgumentException("Id não pode ser menor ou igual zero")
                : id;

        public void SetName(string name) =>
            Name = string.IsNullOrWhiteSpace(name)
                ? throw new ArgumentException("Nome não pode ser nulo")
                : name;

        public void SetCnpj(string cnpj) =>
            Cnpj = string.IsNullOrWhiteSpace(cnpj)
                ? throw new ArgumentException("CNPJ não pode ser nulo")
                : cnpj;

        public void SetPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Número de não pode ser nulo");

            PhoneNumber = phoneNumber.Length switch
            {
                > 13 =>
                    throw new ArgumentException("Número de telefone não ter mais de 13 digitos."),
                < 13 =>
                    throw new ArgumentException("Número de telefone não ter menos de 13 digitos."),
                _ => phoneNumber
            };
        }

        public void SetEmail(string email) =>
            Email = string.IsNullOrWhiteSpace(email)
                ? throw new ArgumentException("Email não pode ser nulo")
                : email;
    }
}