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




    }
}
