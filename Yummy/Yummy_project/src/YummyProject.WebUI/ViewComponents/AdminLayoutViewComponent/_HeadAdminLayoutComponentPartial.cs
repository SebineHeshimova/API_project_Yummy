using Microsoft.AspNetCore.Mvc;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _HeadAdminLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
