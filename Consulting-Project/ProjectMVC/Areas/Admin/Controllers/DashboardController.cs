using Microsoft.AspNetCore.Mvc;
using ProjectBL.Services;
using ProjectDAL.Models;
using ProjectMVC.ViewModels;

namespace ProjectMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly CartService _cartService;

    public DashboardController(CartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        List<TeamCart> carts = _cartService.ReadMembers();
        return View(carts);
    }

    #region CREATE

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateCartVM newVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (newVM.File is not null)
        {
            string filename = Path.GetFileNameWithoutExtension(newVM.File.FileName);
            string extension = Path.GetExtension(newVM.File.FileName);
            string resultname = filename + Guid.NewGuid().ToString() + extension;

            string uploadedImgPath = @"C:\Users\HP\source\repos\Consulting-Project\ProjectMVC\wwwroot\assets\uploadedImages";
            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }

            uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
            using FileStream stream = new FileStream(uploadedImgPath, FileMode.Create);
            newVM.File.CopyTo(stream);

            TeamCart newMember = new TeamCart
            {
                Name = newVM.Name,
                Description = newVM.Description,
                ImgUrl = resultname,
                Specialty = newVM.Specialty
            };
            _cartService.AddTeamMember(newMember);
        }
        else
        {
            TeamCart newMember = new TeamCart
            {
                Name = newVM.Name,
                Description = newVM.Description,
                ImgUrl = "user-icon.png",
                Specialty = newVM.Specialty
            };
            _cartService.AddTeamMember(newMember);
        }


            return RedirectToAction(nameof(Index));
    }



    #endregion

    #region UPDATE

    public IActionResult Update(int id)
    {


        TeamCart clikedCart = _cartService.GetCartById(id);
        UpdateCartVM updateVM = new UpdateCartVM
        {
            Name = clikedCart.Name,
            Specialty = clikedCart.Specialty,
            Description = clikedCart.Description,
        };

        return View(updateVM);
    }
    [HttpPost]
    public IActionResult Update(int id,UpdateCartVM updatedVM)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (updatedVM.File is not null)
        {
            string extension = Path.GetExtension(updatedVM.File.FileName);
            string filename = Path.GetFileNameWithoutExtension(updatedVM.File.FileName);
            string resultname = filename + Guid.NewGuid().ToString() + extension;

            string uploadedImgPath = @"C:\Users\HP\source\repos\Consulting-Project\ProjectMVC\wwwroot\assets\uploadedImages";

            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }
            uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
           using FileStream stream = new FileStream(uploadedImgPath, FileMode.Create);
            updatedVM.File.CopyTo(stream);

            TeamCart updatedCart = new TeamCart
            {
                Name = updatedVM.Name,
                Specialty = updatedVM.Specialty,
                Description = updatedVM.Description,
                ImgUrl = resultname,
            };

            _cartService.UpdateMembers(id,updatedCart);


        }

        else
        {
            TeamCart clickedCart = _cartService.GetCartById(id);
            TeamCart updatedCart = new TeamCart
            {
                Name = updatedVM.Name,
                Description = updatedVM.Description,
                Specialty = updatedVM.Specialty,
                ImgUrl = clickedCart.ImgUrl,

            };

            _cartService.UpdateMembers(id,updatedCart);
        }



            return RedirectToAction(nameof(Index));
    }


    #endregion



    #region DELETE

    public IActionResult Delete(int id)
    {
        _cartService.DeleteMember(id);

        return RedirectToAction(nameof(Index));
    }

    #endregion

}
