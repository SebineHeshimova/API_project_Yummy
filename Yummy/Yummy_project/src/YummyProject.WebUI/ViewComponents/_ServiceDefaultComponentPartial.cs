using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyProject.WebUI.DTOs.ServiceDTOs;

namespace YummyProject.WebUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _ServiceDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Services/");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var valuues=JsonConvert.DeserializeObject<List<GetServiceDTO>>(jsonData);
                return View(valuues);
            }
            return View();
        }
    }
}
