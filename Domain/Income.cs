using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Income
{
    public int Id { get; set; }

    [Required]
    [Range(0.01, 999999999)]
    public decimal Amount { get; set; }

    [Required]
    [StringLength(100)]
    public string Source { get; set; } = string.Empty;

    [StringLength(50)]
    public string Category { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public decimal TitheAmount { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
