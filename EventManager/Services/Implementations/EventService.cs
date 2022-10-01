using EventManager.Data;
using EventManager.DTOs;
using EventManager.Models;
using EventManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEvent(CreateEventDTO dto)
        {
            _context.Add(new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                Location = dto.Location,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            });

            int saved = await _context.SaveChangesAsync();

            if (saved > 0) return true;

            return false;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            return await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Event>> GetEvents()
        {
            return await _context.Events.Where(e => e.IsDeleted != true).ToListAsync();
        }

        public async Task<bool> UpdateEvent(UpdateEventDTO dto, Guid id)
        {
            var eventdetail = await _context.Events.FindAsync(id);
            if (eventdetail == null) return false;
            eventdetail.Title = dto.Title;
            eventdetail.Description = dto.Description;
            eventdetail.Location = dto.Location;
            eventdetail.StartDate = dto.StartDate;
            eventdetail.EndDate = dto.EndDate;

            _context.Update(eventdetail);

            int updated = await _context.SaveChangesAsync();

            if (updated > 0) return true;

            return false;

        }

        public async Task<bool> DeleteEvent(Guid id)
        {
            var eventdetail = await _context.Events.FindAsync(id);
            if (eventdetail == null) return false;
            eventdetail.IsDeleted = true;

            _context.Update(eventdetail);

            int softDeleted = await _context.SaveChangesAsync();

            if (softDeleted > 0) return true;

            return false;
        }
    }
}
