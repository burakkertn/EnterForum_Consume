using EnterForum_Consume.Dtos.Topic;
using EnterForum_Consume.Dtos.TopicTitle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnterForum_Consume.ViewComponents.Default
{
    public class _GetTopicsByTopicTitle : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetTopicsByTopicTitle(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = (int)TempData["id"];
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5074/api/Topic");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTopicDto>>(jsonData);
                var filteredValues = values.Where(x => x.TopicTitleID == id).ToList();
                return View(filteredValues);
            }
            return View();
        }
    }
}
