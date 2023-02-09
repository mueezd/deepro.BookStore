using deepro.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace deepro.BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string CustomProperty { get; set; }
        [ViewData]
        public string hTitle { get; set; }
        public ViewResult Index()
        {
            hTitle = "Home Page From Conttroler";
            CustomProperty = "Custom Value";

            ViewData["property1"] = "deepro";

            ViewData["book"] = new BookModel() { Id= 1 , Author = "Donasi"};

            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
