using mais_consultas_api.Data.PatientDto.Requests;
using mais_consultas_api.Data.PatientDto.Responses;
using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IPatientService
    {
        PatientResponse Add(PatientInserirRequest request);
        void Remove(int id);
        PatientResponse Update(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password);
        PatientResponse Get(int id);
        PatientSignInResponse SignIn(string email, string password);
    }
}