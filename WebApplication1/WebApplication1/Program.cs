using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

//Agrega conexion al server de BD
var connectionString = builder.Configuration.GetConnectionString("connData");

//Agregar al servicio
builder.Services.AddDbContext<ConnectionDbContext>(
    options =>
        options.UseMySql(connectionString, new MySqlServerVersion(new Version (8, 0, 21))
    ));


// Add services to the container.

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
