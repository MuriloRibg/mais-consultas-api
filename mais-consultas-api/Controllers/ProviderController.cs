using mais_consultas_api.Data.ProviderDto.Requests;
using mais_consultas_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace mais_consultas_api.Controllers
{
    [ApiController]
    [Route("api/provider")]
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
            return Ok(_providerService.List());
        }

        /// <summary>
        /// Insert ProviderDto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] ProviderInsertRequest request) 
            => Ok(_providerService.Insert(request));

        /// <summary>
        /// Update ProviderDto
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public IActionResult Update([FromBody] ProviderUpdateRequest request, int id) =>
            Ok(_providerService.Update(request, id));

        /// <summary>
        /// Delete ProviderDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public IActionResult Deleta(int id)
        {
            _providerService.Delete(id);
            return Ok();
        }
    }
}