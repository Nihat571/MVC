using Charity_Project.Models;
using Charity_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Charity_Project.Controllers
{
	public class HomeController : Controller
	{
		CauseCartService causeCartService = new CauseCartService();
		public IActionResult Index()
		{
			List<CauseCart> causeCarts = causeCartService.ReadCause() ;
			return View(causeCarts);
		}
	}
}
