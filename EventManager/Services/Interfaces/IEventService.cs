using EventManager.DTOs;
using EventManager.Models;

namespace EventManager.Services.Interfaces
{
    public interface IEventService
    {
        Task<bool> CreateEvent(CreateEventDTO dto);
        Task<Event> GetEvent(Guid id);
        Task<List<Event>> GetEvents();
        Task<bool> UpdateEvent(UpdateEventDTO dto, Guid id);
        Task<bool> DeleteEvent(Guid id);
    }
}
