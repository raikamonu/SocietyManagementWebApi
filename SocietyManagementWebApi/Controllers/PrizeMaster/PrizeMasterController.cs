using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.PrizeMaster
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeMasterController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public PrizeMasterController(IUnitOfWork repo)
        {
            _repo = repo;
        }



        [HttpPost("CreatePrizeMaster")]
        public async Task<IActionResult> CreatePrizeMaster(PrizeMasterDTO dto)
        {
            return Ok(await _repo.PrizeMaster.CreatePrizeMaster(dto));
        }

        [HttpGet("GetAllPrizeMaster")]
        public async Task<IActionResult> GetAllPrizeMaster()
        {
            return Ok(await _repo.PrizeMaster.GetAllPrizeMaster());
        }

        [HttpGet("GetPrizeMasterById/{id}")]
        public async Task<IActionResult> GetPrizeMasterById(int id)
        {
            return Ok(await _repo.PrizeMaster.GetPrizeMasterById(id));
        }

        [HttpPut("UpdatePrizeMaster")]
        public async Task<IActionResult> UpdatePrizeMaster(PrizeMasterDTO dto)
        {
            return Ok(await _repo.PrizeMaster.UpdatePrizeMaster(dto));
        }

        [HttpDelete("DeletePrizeMaster/{id}")]
        public async Task<IActionResult> DeletePrizeMaster(int id)
        {
            return Ok(await _repo.PrizeMaster.DeletePrizeMaster(id));
        }




    }
}
