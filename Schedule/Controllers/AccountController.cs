using Microsoft.AspNetCore.Mvc;

namespace Schedule.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
