using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/candidate")]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateApplicationService _service;

        public CandidateController(CandidateApplicationService service)
        {
            _service = service;
        }

        [HttpGet("submit")]
        public async Task<IActionResult> Submit([FromBody] CandidateApplication model)
        {
            await _service.SubmitCandidateApplicationAsync(model);
            return Created();
        }
    }
}
