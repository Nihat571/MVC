using Fashion_Project.Models;
using Fashion_Project.Services;
using Fashion_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fashion_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        ProductService productService = new ProductService();
        public IActionResult Index()
        {
            List<Product> products = productService.ReadProduct();
            return View(products);
        }


        #region Create 
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CreateProductVM productVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("is not valid");
            }
            string filename = Path.GetFileNameWithoutExtension(productVM.File.FileName);
            string extension = Path.GetExtension(productVM.File.FileName);

            string resultname = filename + Guid.NewGuid().ToString() + extension;
            string uploadedImgPath = @"C:\Users\HP\source\repos\Fashion-Project\Fashion-Project\wwwroot\assets\uploadedImages";
            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }

            uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
            using FileStream stream = new FileStream(uploadedImgPath,FileMode.Create);
            productVM.File.CopyTo(stream);

            Product newProduct = new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                ImgUrl = resultname,
                 Price = productVM.Price,
                 State = productVM.State
            };

            productService.CreateProduct(newProduct);
              return RedirectToAction(nameof(Index));
        }
        #endregion

        #region DELETE
        
        public IActionResult Delete(int id)
        {
            productService.DeleteProduct(id); 
            return RedirectToAction(nameof(Index));
        }






        #endregion

        #region UPDATE  

        public IActionResult Update(int id)
        {
            Product clickedProduct = productService.ReadProductById(id);
            UpdateProductVM updateProductVM = new UpdateProductVM
            {
                Name = clickedProduct.Name,
                Description = clickedProduct.Description,
                Price = clickedProduct.Price,
                State = clickedProduct.State,

            };

            return View(updateProductVM);
        }

        [HttpPost]
        public IActionResult Update(int id,UpdateProductVM newVM)
        {
            
                if (!ModelState.IsValid)
                {
                    return BadRequest("error model state");
                }
                if(newVM.File is not null)
                {
                string filename = Path.GetFileNameWithoutExtension(newVM.File.FileName);
                string extension = Path.GetExtension(newVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + extension;

                string uploadedImgPath = @"C:\Users\HP\source\repos\Fashion-Project\Fashion-Project\wwwroot\assets\uploadedImages";
                if (!Directory.Exists(uploadedImgPath))
                {
                    Directory.CreateDirectory(uploadedImgPath);
                }

                uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
                using FileStream fileStream = new FileStream(uploadedImgPath, FileMode.Create);
                newVM.File.CopyTo(fileStream);

                Product newProduct = new Product
                {
                    Name = newVM.Name,
                    Description = newVM.Description,
                    ImgUrl = resultname,
                    State = newVM.State,
                    Price = newVM.Price
                };

            productService.UpdateProduct(id, newProduct);
            }

            



            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
