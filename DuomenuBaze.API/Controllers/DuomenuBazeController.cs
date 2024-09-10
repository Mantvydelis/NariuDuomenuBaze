using Microsoft.AspNetCore.Mvc;

namespace DuomenuBaze.API.Controllers
{
    public class DuomenuBazeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
