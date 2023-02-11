using Microsoft.AspNetCore.Mvc;
using Webbshop.Models;


namespace Webbshop.Controllers
{
    public class OrderController : Controller
    {
        List<Order> allaO = new List<Order>();
        Order O = new Order();
        public IActionResult Index()
        {
            return View(Order.getAllOrder());
        }
        public IActionResult newOrder()
        {
            return View();
        }
        public IActionResult AdminRedigeraOrder(int id)
        {
            Order O = Order.getSingleOrderById(id);

            return View(O);

        }

        public IActionResult RaderaInList(int orderID, int produktID)
        {
            Order.deleteProductInOrder(orderID, produktID);

            return View("Index"); 
        }

        [HttpPost]
        public IActionResult sparaOrder(Order O, int orderID, int produktID)
        {
            string action = Request.Form["action"];
            if (action == "Add")
            {
                Order.addProductInOrder(orderID, produktID);
            }
            else if (action == "Change")
            {
                Order.sparaOrder(O);
            }
            return View("Index", Order.getAllOrder());
        }
        //public IActionResult sparanyOrder(Order O)
        //{
        //    if (Order.sparanyOrder(O) == true)
        //    {
        //        ViewBag.Meddelande = "new order saved";
        //    }
        //    else
        //    {
        //        ViewBag.Meddelande = "Action failed";
        //    }
        //    return View("Index", Order.getAllOrder());
        //}
        //public IActionResult deleteOrder(Order O)
        //{
        //    if (Order.deleteOrder(O) == true)
        //    {
        //        ViewBag.Meddelande = "Order removed";
        //    }
        //    else
        //    {
        //        ViewBag.Meddelande = "Action failed";
        //    }
        //    return View("Index", Order.getAllOrder());
        //}
    }
}
