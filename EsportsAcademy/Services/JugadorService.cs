using EsportsAcademy.Models;

namespace EsportsAcademy.Services;

public interface IJugadorService
{
    IReadOnlyList<Jugador> ObtenerTodos();
    void Agregar(Jugador jugador);
    bool Eliminar(int id);
    bool ExisteNombreEnJuego(string nombre, string juego);
}

// Almacenamiento en memoria (singleton). Sustituible por EF Core + BD.
public class JugadorService : IJugadorService
{
    private readonly List<Jugador> _jugadores = new();
    private readonly object _lock = new();
    private int _siguienteId = 1;

    public IReadOnlyList<Jugador> ObtenerTodos()
    {
        lock (_lock) return _jugadores.OrderBy(j => j.Id).ToList();
    }

    public void Agregar(Jugador jugador)
    {
        lock (_lock)
        {
            jugador.Id = _siguienteId++;
            jugador.FechaRegistro = DateTime.Now;
            _jugadores.Add(jugador);
        }
    }

    public bool Eliminar(int id)
    {
        lock (_lock) return _jugadores.RemoveAll(j => j.Id == id) > 0;
    }

    public bool ExisteNombreEnJuego(string nombre, string juego)
    {
        lock (_lock)
            return _jugadores.Any(j =>
                j.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                j.Juego == juego);
    }
}
