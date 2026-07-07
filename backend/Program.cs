// Servir index.html, script.js y styles.css desde la carpeta padre
var carpetaWeb = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), ".."));

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = carpetaWeb
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Un solo endpoint: recibe el nombre del café y responde con un mensaje
app.MapPost("/comprar", (Compra compra) =>
{
    var mensaje = $"¡Gracias por comprar un {compra.Cafe}!";
    return Results.Ok(new { mensaje });
});

app.Run();

record Compra(string Cafe);
