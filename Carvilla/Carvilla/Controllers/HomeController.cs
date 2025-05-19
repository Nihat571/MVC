using Carvilla.Models;
using Carvilla.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carvilla.Controllers
{
    public class HomeController : Controller
    {
        CarSevice carSevice = new CarSevice();
        public IActionResult Index()
        {
           List<Car> cars = carSevice.ReadCar();
            return View(cars);
        }
    }
}
