using Microsoft.AspNetCore.Mvc;
using Webbshop.Models;
using static Google.Protobuf.WellKnownTypes.Field.Types;

namespace Webbshop.Controllers
{
    public class KundController : Controller
    {
        List<Kund> allaK = new List<Kund>();
        Kund k = new Kund();
        public IActionResult Index()
        {
            return View(Kund.getAllKund());
        }
        public IActionResult newKund()
        {
            string roll = HttpContext.Session.GetString("roll");
            if (roll == null || !roll.Contains("admin"))
            {
                return View("NotAllowed");
            }
            return View();
        }
        public IActionResult redigeraKund(int id)
        {
            string roll = HttpContext.Session.GetString("roll");
            if (roll == null || !roll.Contains("admin"))
            {
                return View("NotAllowed");
            }
            Kund k = Kund.getSingleKundById(id);

            return View(k);

        }
        public IActionResult sparaKund(Kund k)
        {
            string roll = HttpContext.Session.GetString("roll");
            if (roll == null || !roll.Contains("admin"))
            {
                return View("NotAllowed");
            }

            Kund.sparaKund(k);
            return View("Index", Kund.getAllKund());
        }
        public IActionResult sparanyKund(Kund k)
        {
            string roll = HttpContext.Session.GetString("roll");
            if (roll == null || !roll.Contains("admin"))
            {
                return View("NotAllowed");
            }
            if (Kund.sparanyKund(k) == true)
            {
                ViewBag.Meddelande = "new customer saved";
            }
            else
            {
                ViewBag.Meddelande = "Action failed";
            }
            return View("Index", Kund.getAllKund());
        }
        public IActionResult deleteKund(Kund k)
        {
            string roll = HttpContext.Session.GetString("roll");
            if (roll == null || !roll.Contains("admin"))
            {
                return View("NotAllowed");
            }
            if (Kund.deleteKund(k) == true)
            {
                ViewBag.Meddelande = "Customer removed";
            }
            else
            {
                ViewBag.Meddelande = "Action failed";
            }
            return View("Index", Kund.getAllKund());
        }
    }
}
