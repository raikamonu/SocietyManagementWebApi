using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.MembershipPlan
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPlanRepositoryController : ControllerBase
    {


        private readonly IUnitOfWork _repo;
        public MembershipPlanRepositoryController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        [HttpPost("CreateMembershipPlan")]
        public async Task<IActionResult> CreateMembershipPlan(MembershipPlanDTO dto)
        {
            return Ok(await _repo.MembershipPlan.CreateMembershipPlan(dto));
        }

        [HttpGet("GetAllMembershipPlan")]
        public async Task<IActionResult> GetAllMembershipPlan()
        {
            return Ok(await _repo.MembershipPlan.GetAllMembershipPlan());
        }

        [HttpGet("GetMembershipPlanById/{id}")]
        public async Task<IActionResult> GetMembershipPlan(int id)
        {
            return Ok(await _repo.MembershipPlan.GetMembershipPlanById(id));
        }

        [HttpPut("UpdateMembershipPlan")]
        public async Task<IActionResult> UpdateMembershipPlan(MembershipPlanDTO dto)
        {
            return Ok(await _repo.MembershipPlan.UpdateMembershipPlan(dto));
        }

        [HttpDelete("DeleteMembershipPlan/{id}")]
        public async Task<IActionResult> DeleteMembershipPlan(int id)
        {
            return Ok(await _repo.MembershipPlan.DeleteMembershipPlan(id));
        }



    }
}
