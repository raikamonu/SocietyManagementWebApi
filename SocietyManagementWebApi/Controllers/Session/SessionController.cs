using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.Session
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IUnitOfWork _repo;
        public SessionController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        [HttpPost("CreateSession")]
        public async Task<IActionResult> CreateSession(SessionDTO input)
        {
            var result = await _repo.Session.CreateSession(input);
            return Ok(result);
        }


        [HttpGet("GetAllSession")]
        public async Task<IActionResult> GetAllSession()
        {
            var result = await _repo.Session.GetAllSession();
            return Ok(result);
        }


        [HttpGet("GetSessionById/{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var result = await _repo.Session.GetSessionById(id);
            return Ok(result);
        }


        [HttpPut("UpdateSession")]
        public async Task<IActionResult> UpdateSession(SessionDTO input)
        {
            var result = await _repo.Session.UpdateSession(input);
            return Ok(result);
        }


        [HttpDelete("DeleteSession/{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var result = await _repo.Session.DeleteSession(id);
            return Ok(result);
        }






    }
}
