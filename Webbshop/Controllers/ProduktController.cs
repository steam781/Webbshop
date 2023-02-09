using Microsoft.AspNetCore.Mvc;
using Webbshop.Models;

namespace Webbshop.Controllers
{
    public class ProduktController : Controller
    {
        List<Produkt> allaP = new List<Produkt>();
        Produkt P = new Produkt();
        public IActionResult Index()
        {
            return View(Produkt.getAllProdukt());
        }
        public IActionResult newProdukt()
        {    
            return View();
        }
        public IActionResult redigeraProdukt(int id)
        {
            Produkt p = Produkt.getSingleProduktById(id);
            
            return View(p);

        }
        public IActionResult sparaProdukt(Produkt p)
        {
            Produkt.sparaProdukt(p);
            return View("Index", Produkt.getAllProdukt());
        }
        public IActionResult sparanyProdukt(Produkt p)
        {
            if (Produkt.sparanyProdukt(p) == true)
            {
                ViewBag.Meddelande = "new product saved";
            }
            else
            {
                ViewBag.Meddelande = "Action failed";
            }
                return View("Index", Produkt.getAllProdukt());
        }
        public IActionResult deleteProdukt(Produkt p)
        {
            if (Produkt.deleteProdukt(p) == true)
            {
                ViewBag.Meddelande = "product removed";
            }
            else
            {
                ViewBag.Meddelande = "Action failed";
            }
            return View("Index", Produkt.getAllProdukt());
        }
    }
}
