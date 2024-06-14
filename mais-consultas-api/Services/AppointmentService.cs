using AutoMapper;
using FluentResults;
using mais_consultas_api.Data;
using mais_consultas_api.Data.AppointmentDto.Requests;
using mais_consultas_api.Data.AppointmentDto.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Models.Enumerators;
using mais_consultas_api.Services.Interfaces;
using mais_consultas_api.Services.Uteis;

namespace mais_consultas_api.Services
{
    public class AppointmentService(AppDbContext context, IMapper mapper) : IAppointmentService
    {
        public AppointmentResponse Add(DateTime dateTime, int idService, int IdProvider, int IdPatient)
        {
            Professional? professional = context.Professionals.FirstOrDefault(x => x.Service.Id == idService);
            if (professional is null)
                throw new Exception("O serviço enviado não possui un Professional");

            Provider? provider = context.Providers.FirstOrDefault(x => x.Id == IdProvider);
            if (provider is null)
                throw new Exception("ProviderDto not found");

            Patient? patient = context.Patient.FirstOrDefault(x => x.Id == IdPatient);
            if (patient is null)
                throw new Exception("PatientDto not found");
            
            Appointment appointment = new(dateTime, professional, provider, patient);
            
            context.Add(appointment);
            context.SaveChanges();
            return mapper.Map<AppointmentResponse>(appointment);
        }

        public Result<IEnumerable<Appointment>> GetAll(AppointmentGetRequest request)
        {
            IQueryable<Appointment> query = context.Appointments;

            if (request.StartDateTime is not null)
                query = query.Where(a =>
                    a.DateTime >= request.StartDateTime &&
                    a.DateTime <= (request.EndDateTime ?? request.StartDateTime.Value.AddDays(7)));

            if (request.ProfessionalId is not null)
                query = query.Where(a => a.Professional.Id == request.ProfessionalId);

            if (request.ProviderId is not null)
                query = query.Where(a => a.Id_Provider == request.ProviderId);

            return Result.Ok(query.AsEnumerable());
        }

        public Result<Appointment> Get(int id)
        {
            var appointment = context.Appointments.FirstOrDefault(x => x.Id == id);
            return appointment is null ? Result.Fail("AppointmentDto not found") : Result.Ok(appointment);
        }

        public Result<Appointment> Update(int id, DateTime dateTime, int professionalId, int providerId, int patientId)
        {
            Result<Appointment> appointment = Get(id);

            if (appointment.IsFailed)
                return appointment;

            Professional professional = context.Professionals.First(x => x.Id == professionalId);
            Provider provider = context.Providers.First(x => x.Id == providerId);
            Patient patient = context.Patient.First(x => x.Id == patientId);

            appointment.Value.SetDateTime(dateTime);
            appointment.Value.SetProfessional(professional);
            appointment.Value.SetProvider(provider);
            appointment.Value.SetPatient(patient);

            context.Appointments.Update(appointment.Value);
            context.SaveChanges();
            return Result.Ok(appointment.Value);
        }

        public Result Cancel(int id)
        {
            Result<Appointment> appointment = Get(id);

            if (appointment.IsFailed)
                return appointment.ToResult();

            appointment.Value.SetStatus(AppointmentStatusEnum.Canceled);

            context.Appointments.Update(appointment.Value);
            context.SaveChanges();
            return Result.Ok();
        }

        public IList<AppointmentTimesResponse> GetTimes(AppointmentGetTimeRequest request)
        {
            IList<AppointmentTimesResponse> responses = Times.GetResponsesTimes();
            IQueryable<Appointment> query = context.Appointments.AsQueryable();
            if (request.IdProvider > 0)
                query = query.Where(a => a.Provider.Id == request.IdProvider);

            if (request.IdProfessional > 0)
                query = query.Where(a => a.Professional.Id == request.IdProfessional);

            if (request.IdService > 0)
                query = query.Where(a => a.Professional.Service.Id == request.IdService);

            query = request.DataConsulta != DateTime.MinValue
                ? query.Where(a => a.DateTime.Date == request.DataConsulta.Date)
                : query.Where(a => a.DateTime.Date == DateTime.Now.Date);

            IList<Appointment> appointments = query.Where(a => a.Status == AppointmentStatusEnum.Scheduled).ToList();

            foreach (Appointment appointment in appointments)
            {
                foreach (AppointmentTimesResponse response in responses)
                {
                    if (appointment.DateTime.TimeOfDay.ToString(@"hh\:mm").Contains(response.Time))
                        response.Available = false;
                    
                }
            }

            return responses;
        }
    }
}