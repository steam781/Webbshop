using Microsoft.AspNetCore.Mvc;
using Webbshop.Models;

namespace Webbshop.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Employee emp)
        {
            ModelState.Remove("name");
            ModelState.Remove("role");

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            Employee nyBesökare = Employee.GetEmployeeByMail(emp.mailadress);

            // Check if password is correct
            if (nyBesökare.password != emp.password)
            {
                ModelState.AddModelError("password", "Incorrect password");
                return View("Index");
            }

            HttpContext.Session.SetString("mailadress", nyBesökare.mailadress);
            HttpContext.Session.SetString("name", nyBesökare.name);
            HttpContext.Session.SetString("role", nyBesökare.role);

            return RedirectToAction("Index", "Home");
        }
    }
}