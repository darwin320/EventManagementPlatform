using Microsoft.EntityFrameworkCore;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Infrastructure.Data;

namespace EventManagementPlatform.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllAsync(string? title, DateTime? from, DateTime? to, string? location)
        {
            IQueryable<Event> query = _context.Events.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(e => e.Title.Contains(title));
            }
            if (from.HasValue)
            {
                query = query.Where(e => e.DateTime >= from.Value);
            }
            if (to.HasValue)
            {
                query = query.Where(e => e.DateTime <= to.Value);
            }
            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(e => e.Location.Contains(location));
            }

            return await query.ToListAsync();
        }

        public async Task<Event?> GetByIdAsync(int id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task<Event> AddAsync(Event entity)
        {
            _context.Events.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Event entity)
        {
            _context.Events.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Event entity)
        {
            _context.Events.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
