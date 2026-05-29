using Application.DTOs.MasterType;
using Application.Helper;
using Microsoft.AspNetCore.Http;
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




        [HttpPost("CreateMasterTypeDetail")]
        public async Task<IActionResult> CreateMasterTypeDetail(MasterTypeDetailDTO input)
        {
            var result = await _repo.MasterTypeDetail.CreateMasterTypeDetail(input);
            return Ok(result);
        }



        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.MasterTypeDetail.GetAllMasterTypeDetail();
            return Ok(result);

        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.MasterTypeDetail.GetMasterTypeDetailById(id);
            return Ok(result);
        }


        [HttpPut("UpdateMasterTypeDetail")]

        public async Task<IActionResult> UpdateMasterTypeDetail(MasterTypeDetailDTO input)
        {
            var result = await _repo.MasterTypeDetail.UpdateMasterTypeDetail(input);
            return Ok(result);

        }


        [HttpDelete("DeleteMasterTypeDetail/{id}")]
        public async Task<IActionResult> DeleteMasterTypeDetail(int id)
        {
            var result = await _repo.MasterTypeDetail.DeleteMasterTypeDetail(id);
            return Ok(result);
        }






    }
}
