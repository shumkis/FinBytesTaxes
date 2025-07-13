using FinBytesTaxesAPI.Data;
using FinBytesTaxesAPI.Repositories;
using FinBytesTaxesAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddScoped<ICitiesRepository, CitiesRepository>();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<AppDbContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")
    ));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
