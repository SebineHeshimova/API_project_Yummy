using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using YummyProject.WebUI.DTOs.FeedbackDTOs;

namespace YummyProject.WebUI.Controllers
{
    public class FeedbackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IHttpClientFactory _httpClientFactory;

        public FeedbackController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> FeedbackList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Feedbacks");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetFeedbackDTO>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeedback()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackDTO createFeedback)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeedback);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7084/api/Feedbacks", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeedbackList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7084/api/Feedbacks?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeedbackList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFeedback(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7084/api/Feedbacks/GetFeedback?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateFeedbackDTO>(jsonData);
                return View(value);

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeedback(UpdateFeedbackDTO feedbackDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(feedbackDTO);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7084/api/Feedbacks/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeedbackList");
            }
            return View();
        }
    }
}
