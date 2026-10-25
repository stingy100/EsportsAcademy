using EsportsAcademy.Models;
using EsportsAcademy.Services;
using Microsoft.AspNetCore.Mvc;

namespace EsportsAcademy.Controllers;

public class JugadoresController : Controller
{
    private readonly IJugadorService _servicio;

    public JugadoresController(IJugadorService servicio) => _servicio = servicio;

    // GET: /Jugadores  -> lista de inscritos
    public IActionResult Index() => View(_servicio.ObtenerTodos());

    // GET: /Jugadores/Crear  -> muestra el formulario vacío
    [HttpGet]
    public IActionResult Crear() => View(new Jugador());

    // POST: /Jugadores/Crear  -> procesa el formulario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(Jugador jugador)
    {
        // Regla de negocio procesada en C#
        if (!string.IsNullOrWhiteSpace(jugador.Nombre) &&
            !string.IsNullOrWhiteSpace(jugador.Juego) &&
            _servicio.ExisteNombreEnJuego(jugador.Nombre.Trim(), jugador.Juego))
        {
            ModelState.AddModelError(nameof(Jugador.Nombre),
                "Este jugador ya está inscrito en ese juego.");
        }

        if (!ModelState.IsValid)
            return View(jugador); // Reenvía el formulario con los errores

        jugador.Nombre = jugador.Nombre.Trim();
        jugador.Rol = jugador.Rol.Trim();
        _servicio.Agregar(jugador);

        TempData["Mensaje"] = $"¡{jugador.Nombre} fue inscrito correctamente!";
        return RedirectToAction(nameof(Index)); // Patrón Post-Redirect-Get
    }

    // POST: /Jugadores/Eliminar/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Eliminar(int id)
    {
        if (_servicio.Eliminar(id))
            TempData["Mensaje"] = "Participante eliminado.";
        else
            TempData["Error"] = "No se encontró el participante.";

        return RedirectToAction(nameof(Index));
    }
}
