using Microsoft.AspNetCore.Mvc;
using RefitGrupoDeEstudos.Interfaces.External;

namespace RefitGrupoDeEstudos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdviceControllerWithoutRefit : ControllerBase
    {
        private readonly IAdviceServiceApi _adviceServiceApi;

        public AdviceControllerWithoutRefit(IAdviceServiceApi adviceServiceApi)
        {
            _adviceServiceApi = adviceServiceApi;
        }

        [HttpGet("/no-refit")]
        public async Task<IActionResult> Get()
        {
            var result = await _adviceServiceApi.GetAsync();

            return Ok(result);
        }

        [HttpGet("/no-refit/{slipId}")]
        public async Task<IActionResult> Get(string slipId)
        {
            var result = await _adviceServiceApi.GetAsync(slipId);

            return Ok(result);
        }
    }
}
