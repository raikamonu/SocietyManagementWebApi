using Application.Helper;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.Dropdown
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public DropdownController(IUnitOfWork repo)
        {
            _repo = repo;
        }

        [HttpGet("master-type")]
        public async Task<IActionResult> GetMasterTypeDDL()
        {
            var result = await _repo.Dropdown.GetMasterTypeDDL();
            return Ok(result);
        }


        [HttpGet("type-detail-list")]
        public async Task<IActionResult> GetTypeDetailList()
        {
            var result = await _repo.Dropdown.GetTypeDetailList();
            return Ok(result);
        }


        [HttpGet("location-list")]
        public async Task<IActionResult> GetLocationDDL()
        {
            var result = await _repo.Dropdown.GetLocationDDL();
            return Ok(result);
        }



        [HttpGet("typeById")]
        public async Task<IActionResult> GetTypeById(int typeId)
        {
            var result = await _repo.Dropdown.GetTypeById(typeId);
            return Ok(result);
        }


        //[HttpGet("session-list")]
        //public async Task<IActionResult> GetSessionDDL()
        //{
        //    var result = await _repo.Dropdown.GetSessionDDL();
        //    return Ok(result);
        //}

        [HttpGet("session-list")]
        public async Task<IActionResult> GetSessionDDL(int sessionId)
        {
            var result = await _repo.Dropdown.GetSessionDDL(sessionId);
            return Ok(result);
        }


        [HttpGet("state-list")]
        public async Task<IActionResult> GetStateDDL()
        {
            var result = await _repo.Dropdown.GetStateDDL();
            return Ok(result);
        }

        [HttpGet("common-location-list")]
        public async Task<IActionResult> GetCommonLocation(int typeId, int parentId)
        {
            var result = await _repo.Dropdown.GetCommonLocation(typeId, parentId);
            return Ok(result);
        }




    }
}