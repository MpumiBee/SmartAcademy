using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.Service.AuthService;
using SmartAcademyBackend.Service.BookingService;
using SmartAcademyBackend.Service.StudentService;
using SmartAcademyBackend.Service.SubscriptionService;
using SmartAcademyBackend.Service.TutorService;
using SmartAcademyBackend.Service.UserService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer=true,
          ValidIssuer = builder.Configuration["AppSettings:Issuer"],
          ValidateAudience= true,
          ValidAudience = builder.Configuration["AppSettings:Audience"],
          ValidateLifetime=true,
          ValidateIssuerSigningKey=true,
          IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!))

      };
    });

builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

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
