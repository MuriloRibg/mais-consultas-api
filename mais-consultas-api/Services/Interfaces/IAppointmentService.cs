using FluentResults;
using mais_consultas_api.Data.Appointment.Requests;
using mais_consultas_api.Models;

namespace mais_consultas_api.Services.Interfaces
{
    public interface IAppointmentService
    {
        Result<Appointment> Add(DateTime dateTime, int professionalId, int providerId, int patientId);
        Result<Appointment> Get(int id);
        Result<IEnumerable<Appointment>> GetAll(AppointmentGetRequest request);
        Result<Appointment> Update(int id, DateTime dateTime, int professionalId, int providerId, int patientId);
        Result Cancel(int id);
    }
}
