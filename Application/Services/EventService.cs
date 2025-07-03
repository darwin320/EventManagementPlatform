using EventManagementPlatform.Application.DTOs;
using EventManagementPlatform.Domain.Entities;
using EventManagementPlatform.Infrastructure.Repositories;

namespace EventManagementPlatform.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<EventDto>> GetAllAsync(string? title, DateTime? from, DateTime? to, string? location)
        {
            var list = await _repo.GetAllAsync(title, from, to, location);
            return list.Select(ToDto);
        }

        public async Task<EventDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? null : ToDto(entity);
        }

        public async Task<EventDto> CreateAsync(CreateEventDto dto)
        {
            var entity = new Event
            {
                Title = dto.Title,
                DateTime = dto.DateTime,
                Location = dto.Location,
                Description = dto.Description,
                Status = dto.Status
            };
            await _repo.AddAsync(entity);
            return ToDto(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateEventDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity is null)
            {
                return false;
            }

            entity.Title = dto.Title;
            entity.DateTime = dto.DateTime;
            entity.Location = dto.Location;
            entity.Description = dto.Description;
            entity.Status = dto.Status;

            await _repo.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity is null)
            {
                return false;
            }

            await _repo.DeleteAsync(entity);
            return true;
        }

        private static EventDto ToDto(Event e)
        {
            return new EventDto(e.Id, e.Title, e.DateTime, e.Location, e.Description, e.Status);
        }
    }
}
