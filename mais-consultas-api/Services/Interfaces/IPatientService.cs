using mais_consultas_api.Data.PatientDto.Requests;
using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IPatientService
    {
        PatientResponse Add(PatientInserirRequest request);
        void Remove(int id);
        Patient Update(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password);
        Patient Get(int id);
    }
}