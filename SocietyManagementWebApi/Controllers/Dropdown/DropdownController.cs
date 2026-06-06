using Application.DTOs;
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
        public async Task<IActionResult> GetMasterType()
        {
            var result = await _repo.Dropdown.GetMasterType();
            return Ok(result);
        }



        [HttpGet("master-type-detail")]
        public async Task<IActionResult> GetMasterTypeDetail(int masterTypeId)
        {
            var result = await _repo.Dropdown.GetTypeById(masterTypeId);
            return Ok(result);
        }




        [HttpGet("type-detail-list")]
        public async Task<IActionResult> GetTypeDetailList()
        {
            var result = await _repo.Dropdown.GetTypeDetailList();
            return Ok(result);
        }


        [HttpGet("location-list")]
        public async Task<IActionResult> GetLocation()
        {
            var result = await _repo.Dropdown.GetLocation();
            return Ok(result);
        }



        [HttpGet("typeById")]
        public async Task<IActionResult> GetTypeById(int typeId)
        {
            var result = await _repo.Dropdown.GetTypeById(typeId);
            return Ok(result);
        }


        [HttpGet("session-list")]
        public async Task<IActionResult> GetSession(int sessionTypeId)
        {
            var result = await _repo.Dropdown.GetSession(sessionTypeId);
            return Ok(result);
        }



        [HttpGet("common-location-list")]
        public async Task<IActionResult> GetCommonLocation(int typeId, int parentId)
        {
            var result = await _repo.Dropdown.GetCommonLocation(typeId, parentId);
            return Ok(result);
        }




        [HttpGet("program-list")]
        public async Task<IActionResult> GetProgram()
        {
            var result = await _repo.Dropdown.GetProgram();
            return Ok(result);
        }




        [HttpGet("GetMembershipPlanDropdown")]
        public async Task<IActionResult> GetMembershipPlanDropdown()
        {

            var result = await _repo.Dropdown.GetMembershipPlan();
            return Ok(result);
        }




        [HttpGet("prize/sessions")]
        public async Task<IActionResult> GetPrizeSessionDropdown()
        {
            var result = await _repo.Dropdown.GetSessionDropdown();
            return Ok(result);
        }








    }
}