using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.Program
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {

        private readonly IUnitOfWork _repo;
        public ProgramController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        [HttpPost("create-program")]
        public async Task<IActionResult> CreateProgram(ProgramDTO input)
        {
            var result = await _repo.Program.CreateProgram(input);
            return Ok(result);
        }

        [HttpGet("get-all-program")]
        public async Task<IActionResult> GetAllProgram()
        {
            var result = await _repo.Program.GetAllProgram();
            return Ok(result);
        }

        [HttpGet("get-program-by-id/{id}")]
        public async Task<IActionResult> GetProgramById(int id)
        {
            var result = await _repo.Program.GetProgramById(id);
            return Ok(result);
        }

        [HttpPut("update-program")]
        public async Task<IActionResult> UpdateProgram(ProgramDTO input)
        {
            var result = await _repo.Program.UpdateProgram(input);
            return Ok(result);
        }

        [HttpDelete("delete-program/{id}")]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var result = await _repo.Program.DeleteProgram(id);
            return Ok(result);
        }







    }
}
