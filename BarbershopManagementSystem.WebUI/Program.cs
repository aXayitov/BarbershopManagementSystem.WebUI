using BarbershopManagementSystem.WebUI.Extension;
using BarbershopManagementSystem.WebUI.Filters;
using BarbershopManagementSystem.WebUI.Services;
using BarbershopManagementSystem.WebUI.Stores;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
//builder.Services.AddControllersWithViews(options =>
//    options.Filters.Add(new ExceptionFilter()));
builder.Services.AddSingleton<ApiClient>();
builder.Services.AddScoped<IDashboardStore, DashboardStore>();
builder.Services.AddScoped<ICustomerStore, CustomerStore>();
builder.Services.AddScoped<IEmployeeStore, EmployeeStore>();
builder.Services.AddScoped<IEnrollmentStore, EnrollmentStore>();
builder.Services.AddScoped<IPaymentStore, PaymentStore>();
builder.Services.AddScoped<IPositionStore, PositionStore>();
builder.Services.AddScoped<IServiceStore, ServiceStore>();
builder.Services.AddSyncfusion(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient("BarbershopManagementSystem", client =>
{
    client.BaseAddress = new Uri("https://localhost:7275/"); // API bazaviy URL manzili
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
