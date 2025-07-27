using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using YummyProject.WebUI.DTOs.FeedbackDTOs;

namespace YummyProject.WebUI.ViewComponents
{
    public class _FeedbackDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeedbackDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responsMessag = await client.GetAsync("https://localhost:7084/api/Feedbacks/");
            if (responsMessag.IsSuccessStatusCode)
            {
                var jsonData=await responsMessag.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<GetFeedbackDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
