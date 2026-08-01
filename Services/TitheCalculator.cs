using Domain;
using Microsoft.Extensions.Options;

namespace Services;

public class TitheCalculator : ITitheCalculator
{
    private readonly TitheSettings _settings;

    public TitheCalculator(IOptions<TitheSettings> options)
    {
        _settings = options.Value;
    }

    public decimal Calculate(decimal amount)
    {
        var baseAmount = _settings.CalculateOnNet
            ? amount * (1m - _settings.DeductionPercent / 100m)
            : amount;

        return Math.Round(baseAmount * _settings.Rate, 2, MidpointRounding.AwayFromZero);
    }
}
