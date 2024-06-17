using AutoMapper;
using mais_consultas_api.Data;
using mais_consultas_api.Data.PatientDto.Requests;
using mais_consultas_api.Data.PatientDto.Responses;
using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;

namespace mais_consultas_api.Services
{
    public class PatientService(AppDbContext _context, IMapper _mapper, ITokenService _tokenService) : IPatientService
    {
        public PatientResponse Add(PatientInserirRequest request)
        {
            Patient patient = new(request.Cpf, request.Name, request.PhoneNumber, request.BirthdayDate, request.Email, request.Password);
            _context.Patient.Add(patient);
            _context.SaveChanges();
            return _mapper.Map<PatientResponse>(patient);
        }

        public Patient Get(int id)
        {
            return _context.Patient.First(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Patient patient = _context.Patient.First(y => y.Id == id);
            _context.Patient.Remove(patient);
            _context.SaveChanges();
        }

        public Patient Update(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email,
            string password)
        {
            Patient patient = _context.Patient.First(y => y.Id == id);
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

        public PatientSignInResponse SignIn(string email, string password)
        {
            Patient? patient = _context.Patient.FirstOrDefault(p => p.Email == email);

            if (patient == null || patient.CheckPassword(password))
                throw new ArgumentException("Usu�rio ou senha inválidos.");

            string token = _tokenService.GenerateToken(patient);

            return new PatientSignInResponse
            {
                Id = patient.Id,
                Token = token,
                Name = patient.Name
            };
        }
    }
}