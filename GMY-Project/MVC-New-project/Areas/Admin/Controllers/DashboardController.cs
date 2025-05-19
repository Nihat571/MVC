using Microsoft.AspNetCore.Mvc;
using MVC_New_project.Models;
using MVC_New_project.Services;
using MVC_New_project.ViewModels;

namespace MVC_New_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        ProgramService programService = new ProgramService();
        public IActionResult Index()
        {
            List<GymProgram> programs = programService.ReadProgram();
            return View(programs);
        }

        #region CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateProgramVM newVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("BAD REQUEST");
            }

            string filename = Path.GetFileNameWithoutExtension(newVM.File.FileName);

            string extension = Path.GetExtension(newVM.File.FileName);
            string resultName = filename + Guid.NewGuid().ToString() + extension;

            string uploadedImgPath = @"C:\Users\HP\Desktop\MVC\GMY-Project\MVC-New-project\wwwroot\assets\uploadedImages";
            if (!Directory.Exists(uploadedImgPath))
            {
                Directory.CreateDirectory(uploadedImgPath);
            }
            uploadedImgPath = Path.Combine(uploadedImgPath, resultName);
            FileStream fileStream = new FileStream(uploadedImgPath, FileMode.Create);
            newVM.File.CopyTo(fileStream);

            GymProgram newGymProgram = new GymProgram
            {
                Name = newVM.Name,
                Description = newVM.Description,
                ImgUrl = resultName
            };
            programService.AddProgram(newGymProgram);

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region DELETE

        public IActionResult Delete(int id)
        {
            programService.DeleteProgram(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region UPDATE

        public IActionResult Update(int id)
        {
            GymProgram clickedProgram = programService.ReadProgramById(id);
            UpdateProgramVM updateVM = new UpdateProgramVM
            {
                Name = clickedProgram.Name,
                Description = clickedProgram.Description,
            };

            return View(updateVM);
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateProgramVM updatedVM)
        {
            
                if (!ModelState.IsValid)
                {
                    return BadRequest("BAD REQUEST");
                }

               if(updatedVM.File is not null)
            {
                string filename = Path.GetFileNameWithoutExtension(updatedVM.File.FileName);
                string extesion = Path.GetExtension(updatedVM.File.FileName);
                string resultname = filename + Guid.NewGuid().ToString() + extesion;
                string uploadedImgPath = @"C:\Users\II Novbe\source\repos\MVC-New-project\MVC-New-project\wwwroot\assets\uploadedImages";

                if (!Directory.Exists(uploadedImgPath))
                {

                    Directory.CreateDirectory(uploadedImgPath);
                }
                uploadedImgPath = Path.Combine(uploadedImgPath, resultname);
                FileStream fileStream = new FileStream(uploadedImgPath, FileMode.Create);
                updatedVM.File.CopyTo(fileStream);
            

                GymProgram updatedProgram = new GymProgram
                {
                    Name = updatedVM.Name,
                    Description = updatedVM.Description,
                    ImgUrl = resultname
                };
            programService.UpdateProgram(id,updatedProgram);
            }
            var clikedProgram = programService.ReadProgramById(id);

            GymProgram updatedProgramWithoutFile = new GymProgram
            {
                Name = updatedVM.Name,
                Description = updatedVM.Description,
               ImgUrl = clikedProgram.ImgUrl
            };
            programService.UpdateProgram(id, updatedProgramWithoutFile);


            return RedirectToAction(nameof(Index));
        }


        #endregion
    }
}