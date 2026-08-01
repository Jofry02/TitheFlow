using Domain;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IIncomeService, IncomeService>();
builder.Services.AddSingleton<ITitheRecordService, TitheRecordService>();
builder.Services.AddSingleton<ITitheCalculator, TitheCalculator>();
builder.Services.AddSingleton<IDashboardService, DashboardService>();
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
