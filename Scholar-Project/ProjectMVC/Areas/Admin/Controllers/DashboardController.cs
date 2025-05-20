using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProjectBL.Services;
using ProjectDAL.Models;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly CourseCartService _service;
        public DashboardController(CourseCartService courseCartService)
        {
            _service = courseCartService;
        }
        public IActionResult Index()
        {
            List<CourseCart> carts = _service.GetAllCourse();
            return View(carts);
        }


        #region CREATE

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CourseVM newVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
                
            }
            if (newVM.File is not null)
            {
                string filename = Path.GetFileNameWithoutExtension(newVM.File.FileName);
                string excepsion = Path.GetExtension(newVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + excepsion;

                string imgPath = @"C:\Users\II Novbe\source\repos\Scholar-Project\ProjectMVC\wwwroot\assets\uploadedImages";
                if (!Directory.Exists(imgPath))
                {
                    Directory.CreateDirectory(imgPath);
                }

                imgPath = Path.Combine(imgPath, resultname);

                using FileStream stream = new FileStream(imgPath, FileMode.Create);
                newVM.File.CopyTo(stream);

                CourseCart newCart = new CourseCart
                {
                    Name = newVM.Name,
                    Author = newVM.Author,
                    Subject = newVM.Subject,
                    Price = newVM.Price,
                    ImgUrl = resultname
                };

                _service.AddCourse(newCart);

            }
            else
            {
                CourseCart newCart = new CourseCart
                {
                    Name = newVM.Name,
                    Author = newVM.Author,
                    Subject = newVM.Subject,
                    Price = newVM.Price,
                    ImgUrl = "default-image.webp"
                };

                _service.AddCourse(newCart);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region DELETE

        public IActionResult Delete(int id)
        {
            _service.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region UPDATE

        public IActionResult Update(int id)
        {
            CourseCart clickedCart = _service.GetCourseById(id);

            CourseVM updatedVM = new CourseVM
            {
                Author = clickedCart.Author,
                Subject = clickedCart.Subject,
                Price = clickedCart.Price,
                Name = clickedCart.Name,
            };

            return View(updatedVM);
        }
        [HttpPost]

        public IActionResult Update(int id,CourseVM updatedVM)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (updatedVM.File is not null)
            {
                string filename = Path.GetFileNameWithoutExtension(updatedVM.File.FileName);
                string extension = Path.GetExtension(updatedVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + extension;

                string imgPath = @"C:\Users\II Novbe\source\repos\Scholar-Project\ProjectMVC\wwwroot\assets\uploadedImages";
                if (!Directory.Exists(imgPath))
                {
                    Directory.CreateDirectory(imgPath);
                }

                imgPath = Path.Combine(imgPath, resultname);
                FileStream stream = new FileStream(imgPath,FileMode.Create);
                updatedVM.File.CopyTo(stream);

                CourseCart updatedCourse = new CourseCart
                {
                    Name = updatedVM.Name,
                    Author = updatedVM.Author,
                    Price = updatedVM.Price,
                    ImgUrl = resultname,
                    Subject = updatedVM.Subject,
                };
                _service.UpdateCourse(id,updatedCourse);
            }
            else
            {
                CourseCart updatedCourse = new CourseCart
                {
                    Name = updatedVM.Name,
                    Author = updatedVM.Author,
                    Price = updatedVM.Price,
                    ImgUrl = "default-image.webp",
                    Subject = updatedVM.Subject,
                };
                _service.UpdateCourse(id, updatedCourse);
            }



            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
