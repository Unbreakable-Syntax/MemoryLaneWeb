using MemoryUserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICaregiverPatientService, PostgresCaregiverPatient>();
builder.Services.AddScoped<IChatMessageService, PostgresChatMessages>();
builder.Services.AddScoped<IEmergencyAlertService, PostgresEmergencyAlerts>();
builder.Services.AddScoped<IFamilyPatientService, PostgresFamilyPatient>();
builder.Services.AddScoped<IPatientLocationService, PostgresPatientLocations>();
builder.Services.AddScoped<IPatientService, PostgresPatient>();
builder.Services.AddScoped<IReminderService, PostgresReminders>();
builder.Services.AddScoped<ISafezoneService, PostgresSafezone>();
builder.Services.AddScoped<IUserService, PostgresUsers>();

var app = builder.Build();

// app.MapGet("/hello", () => "Hello from ASP.NET!");  // Sample GET /hello
// app.MapGet("/user", () => new { name = "Owen", level = "learning ASP.NET" });  // Sample GET /user with JSON output

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Urls.Add($"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT")}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
