using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using YummyProject.WebUI.DTOs.MessageDTOs;

namespace YummyProject.WebUI.ViewComponents.AdminLayoutViewComponent
{
    public class _NavbarMessageAdminLayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarMessageAdminLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Messages/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetMessageByIsReadDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
