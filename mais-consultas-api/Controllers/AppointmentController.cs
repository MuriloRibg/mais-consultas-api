using FluentResults;
using mais_consultas_api.Data.Appointment.Requests;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mais_consultas_api.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}", Name = "GetAppointment")]
        public ActionResult<Appointment> Get(int id)
        {
            var response = _appointmentService.Get(id);

            if (response.IsFailed)
                return NotFound(response);

            return Ok(response.Value);
        }

        [HttpPost]
        public ActionResult<Appointment> Insert([FromBody] AppointmentInsertRequest request)
        {
            var response = _appointmentService.Add(request.DateTime, request.ProfessionalId, request.ProviderId, request.PatientId);

            if (response.IsFailed)
                return BadRequest(response);

            return CreatedAtRoute("GetAppointment", response);
        }

        [HttpPut("{id}")]
        public ActionResult<Appointment> Update(int id, [FromBody] AppointmentUpdateRequest request)
        {
            var response = _appointmentService.Update(id, request.DateTime, request.ProfessionalId, request.ProviderId, request.PatientId);

            if (response.IsFailed)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}/cancel")]
        public ActionResult Cancel(int id)
        {
            var response = _appointmentService.Cancel(id);

            if (response.IsFailed)
                return BadRequest(response);

            return NoContent();
        }
    }
}
