using projectef;
using projectef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p =>p.UseInMemoryDatabase("TareasDB"));
//Conectado a base de datos SQL server
/*PAra solucionar el error:
Microsoft.Data.SqlClient.SqlException (0x80131904): A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - La cadena de certificación fue emitida por una entidad en la que no se confía.)
AGREGAR LO SIGUIENTE A LA CADENA DE CONEXION:TrustServerCertificate=True:
"Data Source=LAPTOP-731U8C1L\\MSSQLSERVER2014;Initial Catalog=TareasDb;user id=sa;password=contraseña;TrustServerCertificate=True"
*/
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
dbContext.Database.EnsureCreated();
return Results.Ok("Base de datos creada: "+ dbContext.Database.IsInMemory());

});

app.Run();
