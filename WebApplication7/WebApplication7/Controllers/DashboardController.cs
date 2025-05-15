using Microsoft.AspNetCore.Mvc;

namespace WebApplication7.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() => View("Page", "عن المبادرة");
        public IActionResult Indicators() => View("Page", "مؤشرات المبادرة");
        public IActionResult Services() => View("Page", "خدمات المبادرة");
        public IActionResult Media() => View();
        public IActionResult Contact() => View("Page", "تواصل معنا");
    }
}

