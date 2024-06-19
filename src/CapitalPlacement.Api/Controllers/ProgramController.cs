using CapitalPlacement.Api.Models;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Api.Controllers
{
    [ApiController]
    [Route("/api/v1/program")]
    public class ProgramController : ControllerBase
    {
        private readonly ProgramService _service;

        public ProgramController(ProgramService service)
        {
            _service = service;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateForm([FromBody] ProgramModel model)
        {
            await _service.CreateProgram(model);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateForm([FromBody] ProgramModel model, string id)
        {
            model.Id = id;
            var response = await _service.UpdateQuestions(model);
            var result = new ResponseModel
            {
                Data = response,
                HasError = false,
                Message = "Successful"
            };
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForm(string id)
        {
            var response = await _service.GetById(id);
            var result = new ResponseModel
            {
                Data = response,
                HasError = false,
                Message = "Successful"
            };
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(string id)
        {
            await _service.Delete(id);
            var result = new ResponseModel
            {
                HasError = false,
                Message = "Successful"
            };
            return Ok(result);
        }
    }
}
