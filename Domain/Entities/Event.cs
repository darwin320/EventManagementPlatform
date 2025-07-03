using EventManagementPlatform.Domain.Enums;

namespace EventManagementPlatform.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public EventStatus Status { get; set; } = EventStatus.Upcoming;
    }
}
