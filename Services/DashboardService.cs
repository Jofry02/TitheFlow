using Domain;
using TitheFlow.Models;

namespace Services;

public class DashboardService : IDashboardService
{
    private readonly IIncomeService _incomes;

    public DashboardService(IIncomeService incomes)
    {
        _incomes = incomes;
    }

    public DashboardViewModel GetSummary()
    {
        var incomes = _incomes.GetAll().ToList();

        return new DashboardViewModel
        {
            TotalIncomes = incomes.Count,
            TotalIncome = incomes.Sum(i => i.Amount),
            TotalTitheCalculated = incomes.Sum(i => i.TitheAmount),
            TotalTithePaid = incomes.Where(i => i.TithePaid).Sum(i => i.TitheAmount),
            Monthly = incomes
                .GroupBy(i => new { i.Date.Year, i.Date.Month })
                .Select(g => new MonthlySummary
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Incomes = g.Count(),
                    Income = g.Sum(i => i.Amount),
                    Tithe = g.Sum(i => i.TitheAmount),
                    TithePaid = g.Where(i => i.TithePaid).Sum(i => i.TitheAmount)
                })
                .OrderByDescending(m => m.Year)
                .ThenByDescending(m => m.Month)
                .ToList()
        };
    }
}
