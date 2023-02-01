using Microsoft.AspNetCore.Mvc;

namespace deepro.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //var obj = new { Id = 1, Name = "deepro" };
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
