namespace Domain;

public class TitheSettings
{
    public decimal Rate { get; set; } = 0.10m;
    public bool CalculateOnNet { get; set; }
    public decimal DeductionPercent { get; set; }
}
