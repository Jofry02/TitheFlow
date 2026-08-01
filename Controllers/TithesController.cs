using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

public class TithesController : Controller
{
    private readonly ITitheRecordService _titheRecords;

    public TithesController(ITitheRecordService titheRecords)
    {
        _titheRecords = titheRecords;
    }

    public IActionResult Index()
    {
        return View(_titheRecords.GetAll().ToList());
    }
}
