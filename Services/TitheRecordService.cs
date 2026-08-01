using Domain;

namespace Services;

public class TitheRecordService : ITitheRecordService
{
    private readonly List<TitheRecord> _records = new();
    private int _nextId = 1;

    public IEnumerable<TitheRecord> GetAll()
    {
        return _records.OrderByDescending(r => r.Date).ToList();
    }

    public TitheRecord? GetByIncomeId(int incomeId)
    {
        return _records.FirstOrDefault(r => r.IncomeId == incomeId);
    }

    public void Add(Income income, decimal titheAmount, bool titheOnNet)
    {
        RemoveByIncomeId(income.Id);
        _records.Add(new TitheRecord
        {
            Id = _nextId++,
            IncomeId = income.Id,
            IncomeAmount = income.Amount,
            TitheAmount = titheAmount,
            TitheOnNet = titheOnNet,
            Date = income.Date
        });
    }

    public bool RemoveByIncomeId(int incomeId)
    {
        return _records.RemoveAll(r => r.IncomeId == incomeId) > 0;
    }
}
