using mais_consultas_api.Data.ProfileDto.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mais_consultas_api.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Patient> Get(int id)
        {
            var response = _patientService.Get(id);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<PatientResponse> Post(string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password)
        {
            PatientResponse response = _patientService.Add(cpf, name, phoneNumber, birthdayDate, email, password);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Patient> Put(int id, string cpf, string name, string phoneNumber, DateTime birthdayDate, string email, string password)
        {
            var response = _patientService.Update(id, cpf, name, phoneNumber, birthdayDate, email, password);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _patientService.Remove(id);
            return Ok();
        }
    }
}
