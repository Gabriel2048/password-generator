using PasswordGenerator.Api.Middlewares;
using PasswordGenerator.Application;
using PasswordGenerator.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddLogging(c => c.AddConsole());
builder.Services.AddCors(p => p.AddPolicy("local", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("local");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ValidationErrorMiddleware>();

app.Run();
