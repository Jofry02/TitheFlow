using System.Globalization;
using System.Text;
using Domain;

namespace Services;

public class ReportService : IReportService
{
    private readonly IIncomeService _incomes;

    public ReportService(IIncomeService incomes)
    {
        _incomes = incomes;
    }

    public IEnumerable<Income> GetByDateRange(DateTime? from, DateTime? to)
    {
        return _incomes.GetAll().Where(i =>
            (!from.HasValue || i.Date.Date >= from.Value.Date) &&
            (!to.HasValue || i.Date.Date <= to.Value.Date));
    }

    public byte[] ExportCsv(IEnumerable<Income> incomes)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id,Fecha,Fuente,Categoria,Descripcion,Monto,Diezmo,Entregado");

        foreach (var i in incomes)
        {
            sb.AppendLine(string.Join(',',
                i.Id,
                i.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                EscapeCsv(i.Source),
                EscapeCsv(i.Category),
                EscapeCsv(i.Description),
                i.Amount.ToString("0.00", CultureInfo.InvariantCulture),
                i.TitheAmount.ToString("0.00", CultureInfo.InvariantCulture),
                i.TithePaid ? "Si" : "No"));
        }

        return Encoding.UTF8.GetBytes(sb.ToString());
    }

    private static string EscapeCsv(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        return value;
    }
}
