using Domain;

namespace Services;

public interface IIncomeService
{
    IEnumerable<Income> GetAll();
    Income? GetById(int id);
    Income Create(Income income);
    Income Update(Income income);
    bool Delete(int id);
}
