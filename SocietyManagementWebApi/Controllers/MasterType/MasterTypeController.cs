using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.MasterType
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterTypeController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public MasterTypeController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMasterType(MasterTypeDTO input)
        {
            var result = await _repo.MasterType.CreateMasterType(input);
            return Ok(result);
        }


        [HttpGet("get-all")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.MasterType.GetAllMasterType(); 
            return Ok(result);

        }


        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.MasterType.GetMasterTypeById(id);
            return Ok(result);
        }


        [HttpPut("update")]

        public async Task<IActionResult> UpdateMasterType (MasterTypeDTO input)
        {
            var result = await _repo.MasterType.UpdateMasterType(input); 
            return Ok(result);

        }
        

            [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMasterType(int id)
        {
            var result = await _repo.MasterType.DeleteMasterType(id);
            return Ok(result);
        }





    }
}
