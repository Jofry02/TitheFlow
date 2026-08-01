using System.ComponentModel.DataAnnotations;

namespace Domain;

public class TitheRecord
{
    public int Id { get; set; }

    public int IncomeId { get; set; }

    [Required]
    [Range(0.01, 999999999)]
    public decimal IncomeAmount { get; set; }

    public decimal TitheAmount { get; set; }

    public bool TitheOnNet { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
