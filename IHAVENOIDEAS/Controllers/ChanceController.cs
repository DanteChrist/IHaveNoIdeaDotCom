using Microsoft.AspNetCore.Mvc;

namespace IHAVENOIDEAS.Controllers
{
    public class ChanceController : Controller
    {
        public IActionResult Index()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 102);
            ViewData["Chance"] = num;
            return View();
        }
    }
}
