using System.ComponentModel.DataAnnotations;

namespace EsportsAcademy.Models;

public class Jugador
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 80 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Seleccione un juego.")]
    [Display(Name = "Juego principal")]
    public string Juego { get; set; } = string.Empty;

    [Required(ErrorMessage = "El rol es obligatorio.")]
    [StringLength(40, ErrorMessage = "Máximo 40 caracteres.")]
    [Display(Name = "Rol en el juego")]
    public string Rol { get; set; } = string.Empty;

    [Range(16, 60, ErrorMessage = "La edad debe estar entre 16 y 60 años.")]
    public int Edad { get; set; } = 18;

    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}
