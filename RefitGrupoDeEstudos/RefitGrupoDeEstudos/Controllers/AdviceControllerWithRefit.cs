using Microsoft.AspNetCore.Mvc;
using RefitGrupoDeEstudos.Interfaces.External;

namespace RefitGrupoDeEstudos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdviceControllerWithRefit : ControllerBase
    {
        private readonly IAdviceApi _adviceApi;
        private readonly ILogger<AdviceControllerWithRefit> _logger;

        public AdviceControllerWithRefit(ILogger<AdviceControllerWithRefit> logger, IAdviceApi adviceApi)
        {
            _logger = logger;
            _adviceApi = adviceApi;
        }

        [HttpGet("/refit")]
        public async Task<IActionResult> Get()
        {
            var result = await _adviceApi.Get();

            return Ok(result);
        }

        [HttpGet("/refit/{slipId}")]
        public async Task<IActionResult> Get(string slipId)
        {
            var result = await _adviceApi.Get(slipId);

            return Ok(result);
        }
    }
}
