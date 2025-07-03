using EventManagementPlatform.Application.DTOs;

namespace EventManagementPlatform.Application.Services
{
    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllAsync(string? title, DateTime? from, DateTime? to, string? location);
        Task<EventDto?> GetByIdAsync(int id);
        Task<EventDto> CreateAsync(CreateEventDto dto);
        Task<bool> UpdateAsync(int id, UpdateEventDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
