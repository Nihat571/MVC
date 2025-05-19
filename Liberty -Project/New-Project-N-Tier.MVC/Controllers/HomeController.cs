using Microsoft.AspNetCore.Mvc;
using New_Project_N_Tier.BL.Services;
using New_Project_N_Tier.DAL.Models;

namespace New_Project_N_Tier.MVC.Controllers
{
    public class HomeController : Controller
    {
        NTFCartService cartService = new NTFCartService();
        public IActionResult Index()
        {
            List<NTFCart> carts = cartService.ReadCart();
            return View(carts);
        }
    }
}
