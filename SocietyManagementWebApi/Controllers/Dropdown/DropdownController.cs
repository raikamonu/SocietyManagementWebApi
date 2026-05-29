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

        [HttpGet("master-type-parent")]
        public async Task<IActionResult> GetParentDDL()
        {
            var result = await _repo.Dropdown.GetParentDDL();
            return Ok(result);


        }
        [HttpGet("master-type-detail-parent")]
        public async Task<IActionResult> GetMasterTypeParentDDL()
        {
            var result = await _repo.Dropdown.GetMasterTypeParentDDL();
            return Ok(result);

        }





    }
}
