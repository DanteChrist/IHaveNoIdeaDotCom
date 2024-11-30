using Microsoft.AspNetCore.Mvc;

namespace IHAVENOIDEAS.Controllers
{
    public class CoinflipController : Controller
    {
        public IActionResult Index()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 3);
            ViewData["Coinflip"] = num;
            return View();
        }
    }
}
