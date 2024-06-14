using FluentResults;
using mais_consultas_api.Data.AppointmentDto.Requests;
using mais_consultas_api.Data.AppointmentDto.Responses;
using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IAppointmentService
    {
        AppointmentResponse Add(DateTime dateTime, int idService, int IdProvider, int IdPatient);
        Result<Appointment> Get(int id);
        Result<IEnumerable<Appointment>> GetAll(AppointmentGetRequest request);
        Result<Appointment> Update(int id, DateTime dateTime, int professionalId, int providerId, int patientId);
        Result Cancel(int id);
        IList<AppointmentTimesResponse>? GetTimes(AppointmentGetTimeRequest request);
    }
}
