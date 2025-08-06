using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyProject.WebUI.DTOs.NotificationDTOs;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _NavbarNotificationAdminLayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarNotificationAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client= _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7084/api/Notifications/GetNotificationIsReadFalse");
            if(responceMessage.IsSuccessStatusCode)
            {
                var jsondata= await responceMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<GetNotificationByIsReadDTO>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
