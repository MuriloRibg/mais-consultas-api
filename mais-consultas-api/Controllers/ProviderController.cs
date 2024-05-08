using mais_consultas_api.Data.Provider.Requests;
using mais_consultas_api.Data.Provider.Responses;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mais_consultas_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        /// <summary>
        /// List Providers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult List()
        {
            List<ProviderReadResponse> providers = _providerService.List();
            if (providers.Count is 0) return NotFound();
            return Ok(providers);
        }

        /// <summary>
        /// Insert Provider
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] ProviderInsertRequest request) => Ok(_providerService.Insert(request));

        /// <summary>
        /// Update Provider
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public IActionResult Update([FromBody] ProviderUpdateRequest request, int id) =>
            Ok(_providerService.Update(request, id));

        /// <summary>
        /// Delete Provider
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public IActionResult Deleta(int id) => Ok(_providerService.Delete(id));
    }
}