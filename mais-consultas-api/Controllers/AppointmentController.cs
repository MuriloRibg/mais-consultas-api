using FluentResults;
using mais_consultas_api.Data.AppointmentDto.Requests;
using mais_consultas_api.Data.AppointmentDto.Responses;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mais_consultas_api.Controllers
{
    [Route("api/appointment")]
    public class AppointmentController(IAppointmentService appointmentService) : Controller
    {

        [HttpGet("times")]
        public ActionResult<List<AppointmentTimesResponse>> GetTimes([FromQuery] AppointmentGetTimeRequest request)
            => Ok(appointmentService.GetTimes(request));
        
        [HttpGet("{id:int}")]
        public ActionResult<Appointment> Get(int id)
        {
            var response = appointmentService.Get(id);
            if (response.IsFailed)
                return NotFound(response);
            return Ok(response.Value);
        }

        [HttpPost]
        public ActionResult<AppointmentResponse> Insert([FromBody] AppointmentInsertRequest request) 
            =>Ok(appointmentService.Add(request.DateTime, request.IdService, request.IdProvider, request.IdPatient));

        [HttpPut("{id:int}")]
        public ActionResult<Appointment> Update(int id, [FromBody] AppointmentUpdateRequest request)
        {
            Result<Appointment> response = appointmentService.Update(id, request.DateTime, request.ProfessionalId, request.ProviderId, request.PatientId);
            if (response.IsFailed)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPut("{id:int}/cancel")]
        public ActionResult Cancel(int id)
        {
            Result response = appointmentService.Cancel(id);
            if (response.IsFailed)
                return BadRequest(response);
            return NoContent();
        }
    }
}
