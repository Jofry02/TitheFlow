namespace TitheFlow.Models;

public class DashboardViewModel
{
    public int TotalIncomes { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalTitheCalculated { get; set; }
    public decimal TotalTithePaid { get; set; }
    public List<MonthlySummary> Monthly { get; set; } = new();
}

public class MonthlySummary
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int Incomes { get; set; }
    public decimal Income { get; set; }
    public decimal Tithe { get; set; }
    public decimal TithePaid { get; set; }
}
