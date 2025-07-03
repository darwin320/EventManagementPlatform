using System.ComponentModel.DataAnnotations;
using EventManagementPlatform.Domain.Enums;

namespace EventManagementPlatform.Application.DTOs
{
    public record CreateEventDto
    {
        [Required] public string Title { get; init; } = string.Empty;
        [Required] public DateTime DateTime { get; init; }
        [Required] public string Location { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public EventStatus Status { get; init; } = EventStatus.Upcoming;
    }
}
