using AutoMapper;
using FluentResults;
using mais_consultas_api.Data;
using mais_consultas_api.Data.AppointmentDto.Requests;
using mais_consultas_api.Data.AppointmentDto.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Models.Enumerators;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AppointmentResponse Add(DateTime dateTime, int professionalId, int providerId, int patientId)
        {
            Professional? professional = _context.Professionals.FirstOrDefault(x => x.Id == professionalId);
            Provider? provider = _context.Providers.FirstOrDefault(x => x.Id == providerId);
            Patient? patient = _context.Patient.FirstOrDefault(x => x.Id == patientId);

            if (professional is null)
                throw new Exception("ProfessionalDto not found");

            if (provider is null)
                throw new Exception("ProviderDto not found");

            if (patient is null)
                throw new Exception("PatientDto not found");

            Appointment appointment = new(dateTime, professional, provider, patient);
            _context.Add(appointment);
            _context.SaveChanges();
            AppointmentResponse response = _mapper.Map<AppointmentResponse>(appointment);
            return response;
        }

        public Result<IEnumerable<Appointment>> GetAll(AppointmentGetRequest request)
        {
            IQueryable<Appointment> query = _context.Appointments;

            if (request.StartDateTime is not null)
                query = query.Where(a => a.DateTime >= request.StartDateTime && a.DateTime <= (request.EndDateTime ?? request.StartDateTime.Value.AddDays(7)));

            if (request.ProfessionalId is not null)
                query = query.Where(a => a.Professional.Id == request.ProfessionalId);

            if(request.ProviderId is not null)
                query = query.Where(a => a.Id_Provider == request.ProviderId);

            return Result.Ok(query.AsEnumerable());
        }

        public Result<Appointment> Get(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            return appointment is null ? Result.Fail("AppointmentDto not found") : Result.Ok(appointment);
        }

        public Result<Appointment> Update(int id, DateTime dateTime, int professionalId, int providerId, int patientId)
        {
            Result<Appointment> appointment = Get(id);

            if (appointment.IsFailed)
                return appointment;

            Professional professional = _context.Professionals.First(x => x.Id == professionalId);
            Provider provider = _context.Providers.First(x => x.Id == providerId);
            Patient patient = _context.Patient.First(x => x.Id == patientId);

            appointment.Value.SetDateTime(dateTime);
            appointment.Value.SetProfessional(professional);  
            appointment.Value.SetProvider(provider);  
            appointment.Value.SetPatient(patient);

            _context.Appointments.Update(appointment.Value);
            _context.SaveChanges();
            return Result.Ok(appointment.Value);
        }

        public Result Cancel(int id)
        {
            Result<Appointment> appointment = Get(id);

            if (appointment.IsFailed)
                return appointment.ToResult();

            appointment.Value.SetStatus(AppointmentStatusEnum.Canceled);

            _context.Appointments.Update(appointment.Value);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
