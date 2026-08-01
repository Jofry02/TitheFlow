using Domain;

namespace Services;

public interface IReportService
{
    IEnumerable<Income> GetByDateRange(DateTime? from, DateTime? to);
    byte[] ExportCsv(IEnumerable<Income> incomes);
}
