using EnterForum_Consume.Dtos.Topic;
using EnterForum_Consume.Dtos.TopicTitle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace EnterForum_Consume.Controllers
{
    public class NewPostController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public NewPostController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5074/api/TopicTitle");
            List<ResultTopicTitleDto> values = null;

            if (responseMessage.IsSuccessStatusCode)
            {
                var jSonData = await responseMessage.Content.ReadAsStringAsync();
                values = JsonConvert.DeserializeObject<List<ResultTopicTitleDto>>(jSonData);

            }
            List<SelectListItem> topicTitles = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.TopicTitleID.ToString()
                                                }).ToList();

            ViewBag.TopicTitles = topicTitles;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(string title, int topicTitleId, string description)
        {
            CreateTopicDto createTopicDto = new CreateTopicDto()
            {
                Title = title,
                TopicTitleID = topicTitleId,
                Description = description,
                CreateTime = DateTime.Now,
                UserID = 1
            };
            var client = _httpClientFactory.CreateClient();
            var jSonData = JsonConvert.SerializeObject(createTopicDto);
            StringContent stringContent = new StringContent(jSonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5074/api/Topic", stringContent);
            string content = await responseMessage.Content.ReadAsStringAsync();
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Technology");
            }
            return View();
        }
    }
}
