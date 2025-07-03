using EventManagementPlatform.Domain.Enums;

namespace EventManagementPlatform.Application.DTOs
{
    public record EventDto
    (
        int Id,
        string Title,
        DateTime DateTime,
        string Location,
        string Description,
        EventStatus Status
    );
}
