using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.Service.StudentService;
using SmartAcademyBackend.Service.SubscriptionService;
using SmartAcademyBackend.Service.TutorService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITutorService, TutorService>();

builder.Services.AddDbContext<SmartAcademyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var getDayName = new DateOnly(2003,4,25).DayOfWeek.ToString();
Console.WriteLine(getDayName);  

//private readonly SmartAcademyDbContext

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
