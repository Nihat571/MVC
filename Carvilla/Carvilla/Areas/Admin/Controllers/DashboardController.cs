using Carvilla.Models;
using Carvilla.Services;
using Carvilla.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Carvilla.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        CarSevice carSevice = new CarSevice();
        public IActionResult Index()
        {
            List<Car> carDb = carSevice.ReadCar();
            return View(carDb);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Update(int id) 
        {

            var clickedCar = carSevice.GetCarById(id);
            return View(clickedCar);
        }

        [HttpPost]

        public IActionResult Create(CarCreateVM carVM)
        {
       
            if (!ModelState.IsValid)
            {
                return BadRequest("Xeta bash verdi");
            }
            string fileName = Path.GetFileNameWithoutExtension(carVM.ImgFile.FileName);
            string extension = Path.GetExtension(carVM.ImgFile.FileName);

            string resultName = fileName + Guid.NewGuid().ToString() + extension;

            string uploadedImgPath = @"C:\Users\II Novbe\Desktop\MVC\Carvilla\Carvilla\wwwroot\assets\uploadedImages";


            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }
            uploadedImgPath = Path.Combine(uploadedImgPath, resultName);

            using FileStream stream = new FileStream(uploadedImgPath, FileMode.Create);

            carVM.ImgFile.CopyTo(stream);

            Car CreatedCar = new Car 
            { 
                Desc = carVM.Desc,
                HP = carVM.HP,
                ImgUrl  = resultName,
                Model   = carVM.Model,
                Price = carVM.Price,
                Name = carVM.Name,
                Type = carVM.Type,
                Year = carVM.Year,
            };



            carSevice.CreateCar(CreatedCar);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]

        public IActionResult Update(int id, Car updatedCar)
        {
            carSevice.UpdateCar(id,updatedCar);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            carSevice.DeleteCar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
