using Microsoft.AspNetCore.Mvc;
using ProjectBL.Services;
using ProjectDAL.Models;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class DashboardController : Controller
    {
        CartService service = new CartService();
        public IActionResult Index()
        {
            List<VillaCart> carts = service.ReadCart();
            return View(carts);
        }


        #region CREATE

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVillaVM newVM) 
        {
            
                if (!ModelState.IsValid)
                {
                return View();
                }
            string filename = Path.GetFileNameWithoutExtension(newVM.File.FileName);
            string extension = Path.GetExtension(newVM.File.FileName);
            string resultname = filename + Guid.NewGuid().ToString() + extension;
            string uploadedImgPath = @"C:\Users\II Novbe\source\repos\New project\ProjectMVC\wwwroot\Admin\assets\uploadedImages";
            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }
            uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
            using FileStream stream = new FileStream(uploadedImgPath, FileMode.Create);

            newVM.File.CopyTo(stream);

            VillaCart newCart = new VillaCart
            {
                Name = newVM.Name,
                Area = newVM.Area,
                Bathrooms = newVM.Bathrooms,
                Bedrooms = newVM.Bedrooms,
                Floor = newVM.Floor,
                ImgUrl = resultname,
                Parking = newVM.Parking,
                Price = newVM.Price,
                Type = newVM.Type
            };

            service.AddVilla(newCart);






            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Update

        public IActionResult Update(int id)
        {
            VillaCart clickedCart = service.GetCartById(id);
            UpdateVillaVM newVM = new UpdateVillaVM
            {
                Name = clickedCart.Name,
                Area = clickedCart.Area,
                Floor = clickedCart.Floor,
                Bathrooms = clickedCart.Bedrooms,
                Bedrooms = clickedCart.Bedrooms,
                Type = clickedCart.Type,
                Parking = clickedCart.Parking,
                Price = clickedCart.Price,
                

            };

            return View(newVM);
        }

        [HttpPost]
        public IActionResult Update(int id,UpdateVillaVM updatedVM)
        {
            if(updatedVM.File is not null)
            {
                if (!ModelState.IsValid)
                {
                    BadRequest("asdasd");
                }
                string filename = Path.GetFileNameWithoutExtension(updatedVM.File.FileName);
                string extension = Path.GetExtension(updatedVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + extension;
                string uploadedImgPath = @"C:\Users\II Novbe\source\repos\New project\ProjectMVC\wwwroot\Admin\assets\uploadedImages";
                if (!Directory.Exists(uploadedImgPath))
                {
                    Directory.CreateDirectory(uploadedImgPath);
                }
                uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
                using FileStream stream = new FileStream(uploadedImgPath, FileMode.Create);

                updatedVM.File.CopyTo(stream);

                VillaCart updatedVilla = new VillaCart
                {
                    Name = updatedVM.Name,
                    Parking = updatedVM.Parking,
                    Price = updatedVM.Price,
                    Bathrooms = updatedVM.Bathrooms,
                    Bedrooms = updatedVM.Bedrooms,
                    ImgUrl = resultname,
                    Area = updatedVM.Area,
                   Floor = updatedVM.Floor,
                   Type = updatedVM.Type,
                };

                service.UpdateVilla(id,updatedVilla);
            }
            else
            {
                VillaCart clickedVilla = service.GetCartById(id);
                VillaCart updatedVilla = new VillaCart
                {
                    Name = updatedVM.Name,
                    Parking = updatedVM.Parking,
                    Price = updatedVM.Price,
                    Bathrooms = updatedVM.Bathrooms,
                    Bedrooms = updatedVM.Bedrooms,
                    ImgUrl = clickedVilla.ImgUrl,
                    Area = updatedVM.Area,
                    Floor = updatedVM.Floor,
                    Type = updatedVM.Type,
                };

                service.UpdateVilla(id, updatedVilla);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            service.DeleteFilla(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
