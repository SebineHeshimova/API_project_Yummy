using Microsoft.AspNetCore.Mvc;

namespace YummyProject.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
