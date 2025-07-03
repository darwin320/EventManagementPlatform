using EventManagementPlatform.Domain.Entities;

namespace EventManagementPlatform.Infrastructure.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync(string? title, DateTime? from, DateTime? to, string? location);
        Task<Event?> GetByIdAsync(int id);
        Task<Event> AddAsync(Event entity);
        Task UpdateAsync(Event entity);
        Task DeleteAsync(Event entity);
    }
}
