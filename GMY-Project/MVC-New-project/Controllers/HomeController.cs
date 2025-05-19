using Microsoft.AspNetCore.Mvc;
using MVC_New_project.Models;
using MVC_New_project.Services;

namespace MVC_New_project.Controllers
{
    public class HomeController : Controller
    {
        ProgramService programService = new ProgramService();
        public IActionResult Index()
        {
            List<GymProgram> gymPrograms = programService.ReadProgram();
            return View(gymPrograms);
        }
    }
}
