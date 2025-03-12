using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pharmecy.Infrastructure.Data.DbContext;
using MediatR;
using Pharmecy.Application.Handlers;
using MongoDB.Driver;
using Pharmecy.Domain.Interfaces;
using Pharmecy.Infrastructure.Repository;
using Pharmecy.Application.Services;

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
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ProgramDbContext>(option =>
{
    option.UseSqlServer("Server = . ; database = Medicen ; integrated security = true ; trustservercertificate = true");
});
// ثبت mongoDB
builder.Services.AddSingleton(serviceProvider =>
{
    var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
    var database = mongoClient.GetDatabase("PharmacyDB"); // 👈 نام دیتابیس MongoDB
    return database.GetCollection<Pharmecy.Domain.Entities.Log>("Logs"); // 👈 نام کالکشن
});

builder.Services.AddSingleton<IMongoClient>(new MongoClient("mongodb://localhost:27017"));
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<LogService>();

var app = builder.Build();
app.MapGet("/", async (LogService logService) =>
{
    await logService.SaveLogAsync("Application Started", "Info");
    return "Logging to MongoDB";
});
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
