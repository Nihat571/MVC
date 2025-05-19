
using Forella.Models;
using Forella.Services;
using Microsoft.AspNetCore.Mvc;


namespace Forella.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly FlowerService _flowerService;
        public DashboardController()
        {
            _flowerService = new FlowerService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var flowers = _flowerService.ReadFlower();
            return View(flowers);
         
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {

            return View();

 }


        public IActionResult Update()
        {
            return View();
        }
//POST METHODS
            #region CREATE
       

        [HttpPost]
        public IActionResult Create(Flower flower)
        {

            _flowerService.AddFlower(flower);

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region DELETE

        [HttpGet]

        public IActionResult Delete(int id)
        {
            _flowerService.DeleteFlower(id);
            
            return RedirectToAction(nameof(Index));
        }
        #endregion
        public IActionResult Update(int id,Flower flower)
        {
            _flowerService.Update(id,flower);
            return RedirectToAction(nameof(Index));
        }
    }
}

