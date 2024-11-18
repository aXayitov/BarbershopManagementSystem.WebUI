using BarbershopManagementSystem.WebUI.Models;
using BarbershopManagementSystem.WebUI.Stores.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace BarbershopManagementSystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDashboardStore _dashboardStore;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IDashboardStore dashboardStore, ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dashboardStore = dashboardStore ?? throw new ArgumentNullException(nameof(dashboardStore));
        }

        public async Task<IActionResult> Index()
        {
            var dashboard = await _dashboardStore.GetDashboardAsync();

            return View(dashboard);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            var dashboard = await _dashboardStore.GetDashboardAsync();

            return View(dashboard);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorHandler(int statusCode)
        {
            return statusCode switch
            {
                (int)HttpStatusCode.NotFound => RedirectToAction("NotFound"),
                (int)HttpStatusCode.InternalServerError => RedirectToAction("Error"),
                (int)HttpStatusCode.Unauthorized => RedirectToAction("Login", "Account"),
                (int)HttpStatusCode.Forbidden => RedirectToAction("Forbidden"),
                _ => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier })
            };
        }

    }
}
