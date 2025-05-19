using Microsoft.AspNetCore.Mvc;
using ProjectBL.Services;
using ProjectDAL.Models;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        CartService service = new CartService();
        public IActionResult Index()
        {
            List<VillaCart> carts = service.ReadCart();
            return View(carts);
        }
    }
}
