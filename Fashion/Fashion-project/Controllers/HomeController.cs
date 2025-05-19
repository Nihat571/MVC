using Fashion_Project.Models;
using Fashion_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_Project.Controllers
{
    public class HomeController : Controller
    {

        ProductService productService = new ProductService();
        public IActionResult Index()
        {
            List<Product> products = productService.ReadProduct();
            return View(products);
        }
    }
}
