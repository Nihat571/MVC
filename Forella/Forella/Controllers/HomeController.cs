
using Forella.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forella.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            FlowerService flowerService = new FlowerService();
                var flowers = flowerService.ReadFlower();
                return View(flowers);
          
        }
    }
}
