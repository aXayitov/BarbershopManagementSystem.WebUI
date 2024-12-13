using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManagementSystem.WebUI.Controllers
{
    public class AuthController : Controller
    {
		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (model.Username == "manager" && model.Password == "12345")
				{
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Invalid username or password");
			}

			return View(model); 
		}
		public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
