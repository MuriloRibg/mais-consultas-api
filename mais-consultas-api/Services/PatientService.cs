using AutoMapper;
using mais_consultas_api.Data;
using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class PatientService(AppDbContext context, IMapper mapper) : IPatientService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public PatientResponse Add(string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password)
        {
            Patient patient = new(cpf, name, phoneNumber, birthdayDate, email, password);

            _context.Patient.Add(patient);

            _context.SaveChanges();

            return _mapper.Map<PatientResponse>(patient);
        }

        public Patient Get(int id)
        {
            return _context.Patient.Where(x => x.Id == id).First();
        }

        public void Remove(int id)
        {
            Patient patient = _context.Patient.Where(y => y.Id == id).First();
            _context.Patient.Remove(patient);
            _context.SaveChanges();
        }

        public Patient Update(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password)
        {

            Patient patient = _context.Patient.Where(y => y.Id == id).First();
            patient.SetId(id);
            patient.SetCpf(cpf);
            patient.SetName(name);
            patient.SetPhoneNumber(phoneNumber);
            patient.SetBirthdayDate(birthdayDate);
            patient.SetEmail(email);
            patient.SetPassword(password);
            

            _context.Patient.Update(patient);

            _context.SaveChanges();
            return patient;
        }
    }
}