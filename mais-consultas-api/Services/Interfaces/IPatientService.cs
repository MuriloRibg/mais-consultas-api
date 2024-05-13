using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IPatientService
    {
        Patient Add(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password);
        void Remove(int id);
        Patient Update(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password);
        Patient Get(int id);
    }
}