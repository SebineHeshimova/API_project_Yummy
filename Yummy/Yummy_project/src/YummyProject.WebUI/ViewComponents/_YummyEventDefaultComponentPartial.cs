using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyProject.WebUI.DTOs.YummyEventDTOs;

namespace YummyProject.WebUI.ViewComponents
{
    public class _YummyEventDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _YummyEventDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/YummyEvents/");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values= JsonConvert.DeserializeObject<List<GetYummyEventDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
