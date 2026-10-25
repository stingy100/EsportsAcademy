# eSports Academy - ASP.NET Core MVC

**Autor:** Sting Mauricio Ramires
**Institución:** Institución Universitaria de Envigado (IUE)
**Curso:** [NOMBRE DE TU CURSO] - Seguimiento 03

## Descripción
Aplicación web para la inscripción de jugadores en torneos universitarios de eSports
(Liga MOBA, Copa FPS y Circuito F2P). Permite registrar participantes mediante un
formulario con validación, consultarlos en una lista y eliminarlos.

## Enlaces
- **Aplicación publicada:** (https://esportsacademy.onrender.com)
- **Repositorio:** https://github.com/stingy100/EsportsAcademy
- **Video de sustentación:** [PEGA AQUÍ EL ENLACE DE TEAMS]

## Tecnologías
- ASP.NET Core MVC (.NET 8) y C#
- Razor (.cshtml), HTML, CSS y Bootstrap 5
- JavaScript
- Git y GitHub
- Docker y Render (publicación)

## Funcionalidades
- Página de inicio con los torneos disponibles.
- Formulario de inscripción (acciones GET y POST).
- Validación de datos en C# con DataAnnotations y `ModelState`.
- Regla de negocio: no permite inscribir dos veces al mismo jugador en el mismo juego.
- Lista de jugadores inscritos y opción de eliminar.

## Estructura del proyecto
| Carpeta | Responsabilidad |
|---|---|
| `Models/` | Entidad `Jugador` con sus propiedades y validaciones |
| `Controllers/` | `HomeController` y `JugadoresController` (reciben peticiones y eligen la vista) |
| `Views/` | Vistas Razor con Bootstrap |
| `Services/` | Almacenamiento de jugadores en memoria |
| `wwwroot/` | Archivos estáticos (CSS y JavaScript) |

## Cómo ejecutarlo
Requisito: tener instalado el SDK de .NET 8.

```bash
dotnet restore
dotnet run
```
Abrir en el navegador la URL que muestre la consola (por ejemplo `https://localhost:5001`).

## Nota
Los jugadores se guardan en memoria, por lo que se pierden al reiniciar la aplicación.