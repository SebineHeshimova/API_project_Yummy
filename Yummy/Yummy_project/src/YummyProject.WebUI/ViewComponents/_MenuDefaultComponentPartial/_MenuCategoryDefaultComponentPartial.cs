using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using YummyProject.WebUI.DTOs.CategoryDTOs;

namespace YummyProject.WebUI.ViewComponents._MenuDefaultComponentPartial
{
    public class _MenuCategoryDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MenuCategoryDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7084/api/Categories/");
            if(responsMessage.IsSuccessStatusCode)
            {
                var jsonData=await responsMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<GetCategoryDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
