using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;
using WebApplication7.Data;
using System.Linq;

namespace WebApplication7.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            var user = _context.LkpUsers
                .FirstOrDefault(u => u.UserName == model.UserName && u.UserPassword == model.UserPassword);

            if (user != null)
            {
                // ✅ Successful login: redirect to dashboard
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                // ❌ Invalid credentials: show Arabic error
                ViewBag.ErrorMessage = "اسم المستخدم أو كلمة السر غير صحيحة.";
                return View("Index");
            }
        }
    }
}
