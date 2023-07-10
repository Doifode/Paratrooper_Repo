using Microsoft.EntityFrameworkCore;
using SP_ProjectCalling.Data;
using SP_ProjectCalling.Interfaces;
using SP_ProjectCalling.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContextDb>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("EmpConnectionString")));
// dapper 

//String ConnectionString = builder.Configuration.GetConnectionString("EmpConnectionString");

//builder.Services.AddSingleton(new EmployeeService(ConnectionString));

builder.Services.AddScoped<IEmployee, EmployeeService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
