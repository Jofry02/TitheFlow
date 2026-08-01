using System.ComponentModel.DataAnnotations;

namespace Domain;

public class TitheRecord
{
    public int Id { get; set; }

    public int IncomeId { get; set; }

    [Display(Name = "Ingreso")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Range(0.01, 999999999, ErrorMessage = "El campo {0} debe estar entre {1} y {2}.")]
    public decimal IncomeAmount { get; set; }

    public decimal TitheAmount { get; set; }

    [Display(Name = "Base de cálculo")]
    public bool TitheOnNet { get; set; }

    [Display(Name = "Fecha")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
