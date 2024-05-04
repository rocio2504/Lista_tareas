using projectef;
using projectef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(p =>p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(("Data Source=LAPTOPTareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
dbContext.Database.EnsureCreated();
return Results.Ok("Base de datos creada: "+ dbContext.Database.IsInMemory());

});

app.Run();
