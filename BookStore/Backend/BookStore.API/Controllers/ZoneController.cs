using BookStore.API.DTOs;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/zones")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository _zoneRepository;
        public ZoneController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateZoneDto createZoneDto)
        {
            var newZone = createZoneDto.Adapt<Zone>();
            var author = await _zoneRepository.Create(newZone);
            return Ok(author);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateZoneDto updateZoneDto)
        {
            var updatedZone = updateZoneDto.Adapt<Zone>();
            var zone = await _zoneRepository.Update(updatedZone);
            return Ok(zone);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var zones = await _zoneRepository.GetAll();
            return Ok(zones);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _zoneRepository.Delete(id);
            return Ok(result);
        }

    }
}
