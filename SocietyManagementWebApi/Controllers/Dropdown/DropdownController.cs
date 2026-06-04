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


        [HttpGet("session-list")]
        public async Task<IActionResult> GetSessionDDL(int sessionTypeId)
        {
            var result = await _repo.Dropdown.GetSessionDDL(sessionTypeId);
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




        [HttpGet("program-list")]
        public async Task<IActionResult> GetProgramDDL()
        {
            var result = await _repo.Dropdown.GetProgramDDL();
            return Ok(result);
        }




        [HttpGet("GetMembershipPlanDropdown")]
        public async Task<IActionResult> GetMembershipPlanDropdown()
        {

            var result = await _repo.Dropdown.GetMembershipPlanDDL();
            return Ok(result);
        }

        [HttpGet("prize/achievement-types")]
        public async Task<IActionResult> GetAchievementTypeDropdown()
        {
            var result = await _repo.Dropdown.GetTypeById(1);
            return Ok(result);
        }

        [HttpGet("prize/levels")]
        public async Task<IActionResult> GetLevelDropdown()
        {
            var result = await _repo.Dropdown.GetTypeById(2);
            return Ok(result);
        }

        [HttpGet("prize/medal-types")]
        public async Task<IActionResult> GetMedalTypeDropdown()
        {
            var result = await _repo.Dropdown.GetTypeById(3);
            return Ok(result);
        }

        [HttpGet("prize/sessions")]
        public async Task<IActionResult> GetPrizeSessionDropdown()
        {
            var result = await _repo.Dropdown.GetSessionDDL(0);
            return Ok(result);
        }

        
    }
}