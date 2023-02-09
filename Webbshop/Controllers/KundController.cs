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
            return View();
        }
        public IActionResult redigeraKund(int id)
        {
            Kund k = Kund.getSingleKundById(id);

            return View(k);

        }
        public IActionResult sparaKund(Kund k)
        {
            Kund.sparaKund(k);
            return View("Index", Kund.getAllKund());
        }
        public IActionResult sparanyKund(Kund k)
        {
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
