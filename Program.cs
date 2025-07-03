using Microsoft.EntityFrameworkCore;
using EventManagementPlatform.Infrastructure.Data;
using EventManagementPlatform.Infrastructure.Repositories;
using EventManagementPlatform.Application.Services;
using EventManagementPlatform.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

/* ---------- 1.  Add services ---------- */

// SQLite connection string -> appsettings.json > ConnectionStrings:Default
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/* ---------- 2.  Middleware ---------- */

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    ctx.Database.EnsureCreated();

    if (!ctx.Events.Any())
    {
        ctx.Events.Add(new EventManagementPlatform.Domain.Entities.Event
        {
            Title = "Demo Event",
            DateTime = DateTime.UtcNow.AddDays(3),
            Location = "Bogotá",
            Description = "First sample event",
            Status = EventManagementPlatform.Domain.Enums.EventStatus.Upcoming
        });
        ctx.SaveChanges();
    }
}


app.MapEventEndpoints();

app.Run();
