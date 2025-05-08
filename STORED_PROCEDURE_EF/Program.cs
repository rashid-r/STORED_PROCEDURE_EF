global using STORED_PROCEDURE_EF.Db_Context;
global using Microsoft.EntityFrameworkCore;
global using STORED_PROCEDURE_EF.Services;
global using STORED_PROCEDURE_EF.Model;
global using STORED_PROCEDURE_EF.Dto;
global using AutoMapper;
using STORED_PROCEDURE_EF.Auto_Mapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<iEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
