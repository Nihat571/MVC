using Microsoft.AspNetCore.Mvc;
using New_Project_N_Tier.BL.Services;
using New_Project_N_Tier.DAL.Models;
using New_Project_N_Tier.MVC.ViewModels;

namespace New_Project_N_Tier.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        NTFCartService cartServices = new NTFCartService();
        public IActionResult Index()
        {
            List<NTFCart> carts = cartServices.ReadCart();
            return View(carts);
        }

        #region CREATE

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCartVM newCartVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string filename = Path.GetFileNameWithoutExtension(newCartVM.File.FileName);
            string extension = Path.GetExtension(newCartVM.File.FileName);
            string resultname = filename + Guid.NewGuid().ToString() + extension;

            string uploadImgs = @"C:\Users\II Novbe\source\repos\New-Project-N-Tier\New-Project-N-Tier.MVC\wwwroot\assets\uploadImages";
            if(!Directory.Exists(uploadImgs))
            {
                Directory.CreateDirectory(uploadImgs);
            }

            uploadImgs = Path.Combine(uploadImgs,resultname);
            FileStream stream = new FileStream(uploadImgs,FileMode.Create);
            newCartVM.File.CopyTo(stream);

            NTFCart newCart = new NTFCart
            {
                Name = newCartVM.Name,
                Category = newCartVM.Category,
                minNumber = newCartVM.minNumber,
                maxNumber = newCartVM.maxNumber,
                ImgUrl = resultname
            };
            cartServices.AddCart(newCart);


            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region DELETE

        public IActionResult Delete(int id)
        {
            cartServices.DeleteCart(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region UPDATE


        public IActionResult Update(int id)
        {
            NTFCart clickedCart = cartServices.ReadCartById(id);

            UpdateCartVM vm = new UpdateCartVM
            {
                Name= clickedCart.Name,
                Category= clickedCart.Category,
                minNumber = clickedCart.minNumber,
                maxNumber = clickedCart.maxNumber,
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateCartVM updatedVM)
        {
            if (updatedVM.File is not null)
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest("is not valid");
                }
                string filename = Path.GetFileNameWithoutExtension(updatedVM.File.FileName);
                string extension = Path.GetExtension(updatedVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + extension;
                string uploadImgs = @"C:\Users\II Novbe\source\repos\New-Project-N-Tier\New-Project-N-Tier.MVC\wwwroot\assets\uploadImages";
                if (!Directory.Exists(uploadImgs))
                {
                    Directory.CreateDirectory(uploadImgs);
                }
                uploadImgs = Path.Combine(uploadImgs,resultname);
                FileStream stream = new FileStream(uploadImgs, FileMode.Create);
                updatedVM.File.CopyTo(stream);

                NTFCart uploadedCart = new NTFCart
                {
                    Name = updatedVM.Name,
                    Category = updatedVM.Category,
                    minNumber = updatedVM.minNumber,
                    maxNumber = updatedVM.maxNumber,
                    ImgUrl = resultname
                };

                cartServices.UpdateCart(id,uploadedCart);

            }
            //eger File elave olunmazsa else işə duşsün və köhnə şəkil qalsın.
            else
            {
                NTFCart clickedCart = cartServices.ReadCartById(id);
                NTFCart uploadedCart = new NTFCart
                {
                    Name = updatedVM.Name,
                    Category = updatedVM.Category,
                    minNumber = updatedVM.minNumber,
                    maxNumber = updatedVM.maxNumber,
                    ImgUrl = clickedCart.ImgUrl
                };

                cartServices.UpdateCart(id, uploadedCart);
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
