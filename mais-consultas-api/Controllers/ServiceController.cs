using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mais_consultas_api.Controllers
{
    [ApiController]
    [Route("api/service")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        /// <summary>
        /// List Services
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_serviceService.GetAll());
        }
        
        /// <summary>
        /// Add service
        /// </summary>
        /// <param name="price"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert(decimal price, string name) 
            => Ok(_serviceService.Add(price, name));
    }
}