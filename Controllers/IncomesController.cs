using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services;

namespace Controllers;

public class IncomesController : Controller
{
    private readonly IIncomeService _incomes;
    private readonly ITitheCalculator _calculator;
    private readonly ITitheRecordService _titheRecords;
    private readonly TitheSettings _settings;

    public IncomesController(
        IIncomeService incomes,
        ITitheCalculator calculator,
        ITitheRecordService titheRecords,
        IOptions<TitheSettings> settings)
    {
        _incomes = incomes;
        _calculator = calculator;
        _titheRecords = titheRecords;
        _settings = settings.Value;
    }

    public IActionResult Index()
    {
        return View(_incomes.GetAll().ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Income income)
    {
        if (!ModelState.IsValid)
        {
            return View(income);
        }

        income.TitheAmount = _calculator.Calculate(income.Amount);
        var created = _incomes.Create(income);
        _titheRecords.Add(created, income.TitheAmount, _settings.CalculateOnNet);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var income = _incomes.GetById(id);
        if (income is null)
        {
            return NotFound();
        }

        return View(income);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Income income)
    {
        if (id != income.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return View(income);
        }

        income.TitheAmount = _calculator.Calculate(income.Amount);
        _incomes.Update(income);
        _titheRecords.Add(income, income.TitheAmount, _settings.CalculateOnNet);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var income = _incomes.GetById(id);
        if (income is null)
        {
            return NotFound();
        }

        return View(income);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _incomes.Delete(id);
        _titheRecords.RemoveByIncomeId(id);
        return RedirectToAction(nameof(Index));
    }
}
