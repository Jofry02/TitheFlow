using Domain;

namespace Services;

public interface ITitheRecordService
{
    IEnumerable<TitheRecord> GetAll();
    TitheRecord? GetByIncomeId(int incomeId);
    void Add(Income income, decimal titheAmount, bool titheOnNet);
    bool RemoveByIncomeId(int incomeId);
}
