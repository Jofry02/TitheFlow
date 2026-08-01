using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers;

public class IncomesController : Controller
{
    private readonly IIncomeService _incomes;

    public IncomesController(IIncomeService incomes)
    {
        _incomes = incomes;
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

        _incomes.Create(income);
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

        _incomes.Update(income);
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
        return RedirectToAction(nameof(Index));
    }
}
