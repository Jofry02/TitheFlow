using Microsoft.AspNetCore.Mvc;
using Services;
using TitheFlow.Models;

namespace Controllers;

public class ReportsController : Controller
{
    private readonly IReportService _reports;

    public ReportsController(IReportService reports)
    {
        _reports = reports;
    }

    [HttpGet]
    public IActionResult Index(DateTime? from, DateTime? to)
    {
        var model = new ReportViewModel
        {
            From = from,
            To = to,
            Incomes = _reports.GetByDateRange(from, to).ToList()
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Export(DateTime? from, DateTime? to)
    {
        var rows = _reports.GetByDateRange(from, to).ToList();
        var bytes = _reports.ExportCsv(rows);
        var fileName = $"titheflow-reporte-{DateTime.UtcNow:yyyyMMdd-HHmmss}.csv";
        return File(bytes, "text/csv", fileName);
    }
}
