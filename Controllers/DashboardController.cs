using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

public class DashboardController : Controller
{
    private readonly IDashboardService _dashboard;

    public DashboardController(IDashboardService dashboard)
    {
        _dashboard = dashboard;
    }

    public IActionResult Index()
    {
        return View(_dashboard.GetSummary());
    }
}
