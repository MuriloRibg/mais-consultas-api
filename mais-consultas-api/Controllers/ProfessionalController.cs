using mais_consultas_api.Data.ProfessionalDto.Response;
using mais_consultas_api.Models;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mais_consultas_api.Controllers
{
    [Route("api/professional")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        readonly IProfessionalService _professionalService;

        public ProfessionalController(IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Professional>> Get()
        {
            var response = _professionalService.GetAll();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Professional> Get(int id)
        {
            Professional? response = _professionalService.Get(id);
            if (response is null) NotFound("ProfessionalDto não encontrado");
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ProfessionalResponse> Post(string name, int idService, int idProvider)
        {
            ProfessionalResponse response = _professionalService.Add(name, idService, idProvider);
            return Ok(response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Professional> Put(int id, string name, int idService, int idProvider)
        {
            var response = _professionalService.Update(id, name, idService, idProvider);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _professionalService.Remove(id);
            return Ok();
        }
    }
}
