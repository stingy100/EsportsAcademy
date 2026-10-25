using EsportsAcademy.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios (MVC + almacenamiento en memoria)
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IJugadorService, JugadorService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();   // Sirve wwwroot (css, js)
app.UseRouting();
app.UseAuthorization();

// Ruta por defecto: /{controlador}/{accion}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
