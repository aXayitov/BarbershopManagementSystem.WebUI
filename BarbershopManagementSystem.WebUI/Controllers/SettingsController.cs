using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManagementSystem.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index(SettingViewModel setting)
        {


            return View();
        }
    }
}
