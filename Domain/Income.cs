using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Income
{
    public int Id { get; set; }

    [Display(Name = "Monto")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Range(0.01, 999999999, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
    public decimal Amount { get; set; }

    [Display(Name = "Fuente")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(100, ErrorMessage = "El campo {0} no puede superar los {1} caracteres.")]
    public string Source { get; set; } = string.Empty;

    [Display(Name = "Categoría")]
    [StringLength(50, ErrorMessage = "El campo {0} no puede superar los {1} caracteres.")]
    public string? Category { get; set; }

    [Display(Name = "Descripción")]
    [StringLength(500, ErrorMessage = "El campo {0} no puede superar los {1} caracteres.")]
    public string? Description { get; set; }

    public decimal TitheAmount { get; set; }

    [Display(Name = "Diezmo entregado")]
    public bool TithePaid { get; set; }

    [Display(Name = "Fecha")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
