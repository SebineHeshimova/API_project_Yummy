using Microsoft.AspNetCore.Mvc;

namespace YummyProject.WebUI.ViewComponents._MenuDefaultComponentPartial
{
    public class _MenuDefaultComponentPartial:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
