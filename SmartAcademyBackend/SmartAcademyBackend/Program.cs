using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.Service.StudentService;
using SmartAcademyBackend.Service.SubscriptionService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddDbContext<SmartAcademyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
