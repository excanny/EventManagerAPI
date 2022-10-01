using EventManager.DTOs;
using EventManager.Models;
using EventManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }

        [HttpPost("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateEventDTO dto)
        {
            var response = await _eventService.CreateEvent(dto);
            return Ok(response);
        }

        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents()
        {
            var response = await _eventService.GetEvents();
            return Ok(response);
        }

        [HttpGet("GetEvent")]
        public async Task<IActionResult> GetEvent(Guid id)
        {
            var response = await _eventService.GetEvent(id);
            return Ok(response);
        }

        [HttpPut("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(UpdateEventDTO dto, Guid id)
        {
            var response = await _eventService.UpdateEvent(dto, id);
            return Ok(response);
        }

        [HttpDelete("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var response = await _eventService.DeleteEvent(id);
            return Ok(response);
        }
    }
}