using Domain;

namespace Services;

public class IncomeService : IIncomeService
{
    private readonly List<Income> _incomes = new();
    private int _nextId = 1;

    public IEnumerable<Income> GetAll()
    {
        return _incomes.OrderByDescending(i => i.Date).ToList();
    }

    public Income? GetById(int id)
    {
        return _incomes.FirstOrDefault(i => i.Id == id);
    }

    public Income Create(Income income)
    {
        income.Id = _nextId++;
        _incomes.Add(income);
        return income;
    }

    public Income Update(Income income)
    {
        var existing = GetById(income.Id)
            ?? throw new InvalidOperationException("El ingreso no existe.");

        existing.Amount = income.Amount;
        existing.Source = income.Source;
        existing.Category = income.Category;
        existing.Description = income.Description;
        existing.Date = income.Date;
        return existing;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        return existing is not null && _incomes.Remove(existing);
    }
}
