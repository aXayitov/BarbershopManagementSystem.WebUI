using BarbershopManagementSystem.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BarbershopManagementSystem.WebUI.Controllers
{
    public class AuthController : Controller
    {
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF himoyasi
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "manager" && model.Password == "1234")
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
