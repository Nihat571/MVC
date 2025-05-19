using Charity_Project.Models;
using Charity_Project.Services;
using Charity_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Charity_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        CauseCartService cartService = new CauseCartService();
        public IActionResult Index()
        {
            List<CauseCart> carts =  cartService.ReadCause();
            return View(carts);
        }
        #region CREATE
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCartVM createCartVM)
        {
            if (!ModelState.IsValid) 
            {
            return BadRequest("MODELSTATE ERROR!");
            }
            string fileName = Path.GetFileNameWithoutExtension(createCartVM.formFile.FileName);
            string extension = Path.GetExtension(createCartVM.formFile.FileName);
            string resultName = fileName + Guid.NewGuid().ToString() + extension;

            string uploadedImgPath = @"C:\Users\II Novbe\source\repos\Charity-Project\Charity-Project\wwwroot\assets\uploadedImages";

            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }

           uploadedImgPath = Path.Combine(uploadedImgPath,resultName);

            using FileStream fileStream = new FileStream(uploadedImgPath,FileMode.Create);
            createCartVM.formFile.CopyTo(fileStream);

            CauseCart causeCart = new CauseCart
            {
                Name = createCartVM.Name,
                Description = createCartVM.Description,
                ImgUrl = resultName,
                RaisedNumber = createCartVM.RaisedNumber,
                GoalNUmber = createCartVM.GoalNumber
            };

            cartService.AddCart(causeCart);

            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region UPDATE
        
        public IActionResult Update(int id)
        {
            var data = cartService.ReadCauseCartById(id);
            UpdateCartVM cartVM = new UpdateCartVM
            {
                Description = data.Description,
                Name = data.Name,
                GoalNumber = data.GoalNUmber,
                RaisedNumber= data.RaisedNumber,
            };
            return View(cartVM);
        }

        [HttpPost]
        public IActionResult Update(int id,UpdateCartVM updateCartVM )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("data is not valid");
            }

   

            CauseCart clickedCart = cartService.ReadCauseCartById(id);
            if (clickedCart is not null) 
            {
                clickedCart.Name = updateCartVM.Name;
                clickedCart.Description = updateCartVM.Description;
                clickedCart.RaisedNumber = updateCartVM.RaisedNumber;
                clickedCart.GoalNUmber = updateCartVM.GoalNumber;

                if (updateCartVM.formFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(updateCartVM.formFile.FileName);
                    string extension = Path.GetExtension(updateCartVM.formFile.FileName);
                    string resultname = filename + Guid.NewGuid().ToString() + extension;

                    string uploadedImgPath = @"C:\Users\II Novbe\source\repos\Charity-Project\Charity-Project\wwwroot\assets\uploadedImages";

                    if (!Directory.Exists(uploadedImgPath))
                    {
                        Directory.CreateDirectory(uploadedImgPath);
                    }

                    uploadedImgPath = Path.Combine(uploadedImgPath, resultname);

                    using FileStream fileStream = new FileStream(uploadedImgPath, FileMode.Create);

                    updateCartVM.formFile.CopyTo(fileStream);

                    clickedCart.ImgUrl = resultname;
                }
            cartService.UpdateCart(id,clickedCart);
            }


            return RedirectToAction(nameof(Index));
        }

        #endregion



        #region DELETE


        public IActionResult Delete(int id)
        {
            cartService.DeleteCauseCart(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

    }
}
