using EventManagementPlatform.Application.DTOs;
using EventManagementPlatform.Application.Services;

namespace EventManagementPlatform.Api.Endpoints
{
    public static class EventEndpoints
    {
        public static void MapEventEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/events");

            group.MapGet("/", async (
                string? title,
                DateTime? from,
                DateTime? to,
                string? location,
                IEventService service) =>
            {
                var events = await service.GetAllAsync(title, from, to, location);
                return Results.Ok(events);
            });

            group.MapGet("/{id:int}", async (int id, IEventService service) =>
            {
                var ev = await service.GetByIdAsync(id);
                return ev is null ? Results.NotFound() : Results.Ok(ev);
            });

            group.MapPost("/", async (CreateEventDto dto, IEventService service) =>
            {
                var created = await service.CreateAsync(dto);
                return Results.Created($"/events/{created.Id}", created);
            });

            group.MapPut("/{id:int}", async (int id, UpdateEventDto dto, IEventService service) =>
            {
                var updated = await service.UpdateAsync(id, dto);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            group.MapDelete("/{id:int}", async (int id, IEventService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
