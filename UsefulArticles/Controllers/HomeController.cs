using Microsoft.AspNetCore.Mvc;

namespace UsefulArticles.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}