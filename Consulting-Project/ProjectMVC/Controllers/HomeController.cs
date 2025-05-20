using Microsoft.AspNetCore.Mvc;
using ProjectBL.Services;
using ProjectDAL.Models;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CartService _cartService;
        public HomeController(CartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            List<TeamCart> carts = _cartService.ReadMembers(); 
            return View(carts);
        }
    }
}
