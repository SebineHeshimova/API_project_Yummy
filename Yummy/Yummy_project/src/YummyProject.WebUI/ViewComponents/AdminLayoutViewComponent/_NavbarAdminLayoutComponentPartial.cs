using Microsoft.AspNetCore.Mvc;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _NavbarAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
