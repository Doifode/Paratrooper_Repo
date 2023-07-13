using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Data;
using RegistrationAPI.Interface;
using RegistrationAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(Option=> Option.UseSqlServer(builder.Configuration.GetConnectionString("UserRegistrationConnectionstring")));

builder.Services.AddScoped<IUserRegistration, UserRegistrationService>();

// Cros Solution.
builder.Services.AddCors(options =>

    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
