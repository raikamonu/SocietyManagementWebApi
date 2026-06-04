using Application.DTOs;
using Application.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagementWebApi.Controllers.Location
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {


        private readonly IUnitOfWork _repo;
        public LocationController(IUnitOfWork repo)
        {
            _repo = repo;
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] LocationDTO input)
        {
            var result = await _repo.Location.CreateLocation(input);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.Location.GetAllLocation();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.Location.GetLocationById(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] LocationDTO input)
        {
                var result = await _repo.Location.UpdateLocation(input);
            return Ok(result);
        }

        //[HttpPut("update")]
        //public async Task<IActionResult> Update(LocationDTO input)
        //{
        //    var result = await _repo.Location.UpdateLocation(input);
        //    return Ok(result);
        //}

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.Location.DeleteLocation(id);
            return Ok(result);
        }










    }
}
