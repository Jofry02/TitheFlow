using Domain;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
        field => $"El campo {field} es obligatorio.");
    options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(
        () => "Se requiere un valor.");
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "El campo es obligatorio.");
    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
        field => $"El campo {field} debe ser un número.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (value, field) => $"El valor '{value}' no es válido para el campo {field}.");
    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
        value => $"El valor '{value}' no es válido.");
});
builder.Services.AddSingleton<IIncomeService, IncomeService>();
builder.Services.AddSingleton<ITitheRecordService, TitheRecordService>();
builder.Services.AddSingleton<ITitheCalculator, TitheCalculator>();
builder.Services.AddSingleton<IDashboardService, DashboardService>();
builder.Services.AddSingleton<IReportService, ReportService>();
builder.Services.Configure<TitheSettings>(builder.Configuration.GetSection("TitheSettings"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
