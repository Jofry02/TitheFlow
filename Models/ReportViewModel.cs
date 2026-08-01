using Domain;

namespace TitheFlow.Models;

public class ReportViewModel
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public List<Income> Incomes { get; set; } = new();
}
