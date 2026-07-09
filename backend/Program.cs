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
	if (string.IsNullOrWhiteSpace(compra.Cafe))
        return Results.BadRequest(new { error = "Debe indicar un café." });
	
    var mensaje = $"¡Gracias por comprar un {compra.Cafe}!";
    return Results.Ok(new { mensaje });
});

app.MapGet("/menu", () =>
{
    var menu = new[]
    {
        new { nombre = "Capuccino", precio = 2500 },
        new { nombre = "Latte", precio = 2700 },
        new { nombre = "Espresso", precio = 2000 },
    };
    return Results.Ok(menu);
});

app.MapGet("/health", () => Results.Ok(new { estado = "ok" }));

app.Run();

record Compra(string Cafe);
