using FinBytesTaxesAPI.Data;
using FinBytesTaxesAPI.Extensions;
using FinBytesTaxesAPI.Middleware;
using FinBytesTaxesAPI.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddRepositories();
services.AddAppServices();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddCustomAutoMapper();

services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "City taxes API", Version = "v1" });
    options.OperationFilter<AddHeaderOperationFilter>();
});

services.AddDbContext<AppDbContext>(
    option => option.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")
    ));

var app = builder.Build();

app.ApplyMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
