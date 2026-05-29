using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.MasterType
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterTypeDetailController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public MasterTypeDetailController(IUnitOfWork repo)
        {
            _repo = repo;
        }




        [HttpPost("create")]
        public async Task<IActionResult> CreateMasterTypeDetail(MasterTypeDetailDTO input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return BadRequest("Name cannot be null or empty");
            }
            var result = await _repo.MasterTypeDetail.CreateMasterTypeDetail(input);
            return Ok(result);
        }



        [HttpGet("get-all")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.MasterTypeDetail.GetAllMasterTypeDetail();
            return Ok(result);

        }


        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.MasterTypeDetail.GetMasterTypeDetailById(id);
            return Ok(result);
        }


        [HttpPut("update")]

        public async Task<IActionResult> UpdateMasterTypeDetail(MasterTypeDetailDTO input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
            {
                return BadRequest("Name cannot be null or empty");
            }
            var result = await _repo.MasterTypeDetail.UpdateMasterTypeDetail(input);
            return Ok(result);

        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMasterTypeDetail(int id)
        {
            var result = await _repo.MasterTypeDetail.DeleteMasterTypeDetail(id);
            return Ok(result);
        }






    }
}
