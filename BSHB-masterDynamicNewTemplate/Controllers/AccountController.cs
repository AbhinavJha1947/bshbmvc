using BiharStateHousingBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BiharStateHousingBoard.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginVm)
        {
            if(loginVm.UserRole=="Admin" && loginVm.UserId == "bshb" && loginVm.Password == "12345")
            {                
                TempData["UserRole"] = loginVm.UserRole;
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admin(LoginViewModel loginVm)
        {
            if (loginVm.UserRole == "1" && loginVm.UserId == "bshb" && loginVm.Password == "12345")
            {
                HttpContext.Session.SetString("Role", "_Admin");
                TempData["UserId"] = loginVm.UserId;
                return RedirectToAction("Dashboard", "Admin");
            }
            return View();
        }
    }
}
