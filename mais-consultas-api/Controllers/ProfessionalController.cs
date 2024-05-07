using mais_consultas_api.Services;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mais_consultas_api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public ActionResult<Professional> Get(int id)
        {
            var response = _professionalService.Get(id);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Professional> Post(string name, string service, string provider)
        {
            var response = _professionalService.Add(name, service, provider);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<Professional> Put(int id, string name, string service, string provider)
        {
            var response = _professionalService.Update(id, name, service, provider);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _professionalService.Remove(id);
            return Ok();
        }
    }
}
