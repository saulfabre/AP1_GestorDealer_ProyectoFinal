using System.ComponentModel.DataAnnotations;

namespace AP1_GestorDealer_ProyectoFinal.Models;

public class Vehiculos
{
    [Key]
    public int VehiculoId { get; set; }

    [Required(ErrorMessage = "La marca es obligatoria.")]
    [StringLength(50)]
    public string Marca { get; set; } = "";

    [Required(ErrorMessage = "El modelo es obligatorio.")]
    [StringLength(50)]
    public string Modelo { get; set; } = "";

    [Range(1886, 2100, ErrorMessage = "El año del vehículo no es válido.")]
    public int Ano { get; set; }

    [Required(ErrorMessage = "La matrícula es obligatoria.")]
    [StringLength(20)]
    public string Matricula { get; set; } = "";

    [Required(ErrorMessage = "El color es obligatorio.")]
    [StringLength(30)]
    public string Color { get; set; } = "";

    [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Precio { get; set; }

    [Range(0, 2000000, ErrorMessage = "El kilometraje no es válido.")]
    public int Kilometraje { get; set; }

    [Required(ErrorMessage = "El tipo de combustible es obligatorio.")]
    [StringLength(30)]
    public string Combustible { get; set; } = "";

    [Required(ErrorMessage = "El tipo de transmisión es obligatorio.")]
    [StringLength(30)]
    public string Transmision { get; set; } = "";

    [StringLength(500)]
    public string Foto { get; set; } = "";
}
