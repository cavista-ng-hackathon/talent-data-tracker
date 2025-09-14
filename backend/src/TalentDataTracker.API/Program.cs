using Hangfire;
using TalentDataTracker.API.Extensions;
using TalentDataTracker.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
app.UseGlobalExceptionHandler(logger);
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard("/admin/jobs", new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter(builder.Configuration) },
    DashboardTitle = "Jobs Dashboard",
    DisplayStorageConnectionString = false,
    DisplayNameFunc = (_, job) => job.Method.Name,
    DarkModeEnabled = true,
});

app.RunMigrations(true);
app.MapControllers();
app.Run();
