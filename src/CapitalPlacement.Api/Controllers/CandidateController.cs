using CapitalPlacement.Api.Models;
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

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] CandidateApplication model)
        {
            await _service.SubmitCandidateApplicationAsync(model);
            return Ok(new ResponseModel
            {
                HasError = false,
                Message = "Successfully submitted application"
            });
        }

        [HttpGet("submit/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetCandidateApplicationByIdAsync(id);
            var response = new ResponseModel
            {
                Data = result,
                HasError = false,
                Message = "Successful"
                
            };
            return Ok(response);
        }
    }
}
