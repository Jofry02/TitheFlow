using TitheFlow.Models;

namespace Services;

public interface IDashboardService
{
    DashboardViewModel GetSummary();
}
