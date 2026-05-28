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

        [HttpPost("CreateMasterType")]
        public async Task<IActionResult> CreateMasterType(MasterTypeDTO input)
        {
            var result = await _repo.MasterType.CreateMasterType(input);
            return Ok(result);
        }
    }
}
