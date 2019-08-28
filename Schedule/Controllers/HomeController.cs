using Microsoft.AspNetCore.Mvc;

namespace Schedule.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
