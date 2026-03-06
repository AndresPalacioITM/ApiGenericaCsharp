using ApiGenericaCsharp.Repositorios.Abstracciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// public class RepositorioLecturaSqlServer : IRepositorioLecturaTabla
// {
//     private readonly IProveedorConexion _proveedor;
//     public RepositorioLecturaSqlServer(IProveedorConexion proveedor)
//     {
//         _proveedor = proveedor;
//     }
//     public async Task<IReadOnlyList<Dictionary<string, object?>>> ObtenerFilasAsync(string nombreTablla, string? esquema, int? limite)
//     {
//         var cadenaConexion = _proveedor.ObtenerCadenaConexion();
//         // Implementación para obtener filas de una tabla en SQL Server
//         // Aquí se usaría _proveedor para ejecutar la consulta y devolver los resultados
//         return new List<Dictionary<string, object?>>();
//     }
// }


app.Run();



record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
