using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pharmecy.Infrastructure.Data.DbContext;
using MediatR;
using Pharmecy.Application.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// ??? MediatR ???? ??????? ?? Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateMedicineHandler>());// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pharmecy API",
        Version = "v1"
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ProgramDbContext>(option =>
{
    option.UseSqlServer("Server = . ; database = Medicen ; integrated security = true ; trustservercertificate = true");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmecy API V1");
    c.RoutePrefix = string.Empty; // Optional: This will set the Swagger UI at the root URL.
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
