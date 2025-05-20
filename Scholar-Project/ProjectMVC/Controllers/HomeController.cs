using Microsoft.AspNetCore.Mvc;
using ProjectBL.Services;
using ProjectDAL.Models;

namespace ProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CourseCartService _service;
        public HomeController(CourseCartService courseCartService)
        {
            _service = courseCartService;
        }

        public IActionResult Index()
        {
            List<CourseCart> carts = _service.GetAllCourse();
            return View(carts);
        }
    }
}
