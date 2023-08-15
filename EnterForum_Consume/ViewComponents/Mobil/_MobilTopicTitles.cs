using EnterForum_Consume.Dtos.Category;
using EnterForum_Consume.Dtos.TopicTitle;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnterForum_Consume.ViewComponents.Mobil


{
    public class _MobilTopicTitles : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MobilTopicTitles(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5074/api/TopicTitle");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTopicTitleDto>>(jsonData);
                var filteredValues = values.Where(x => x.CategoryID == 6).ToList();
                return View(filteredValues);
            }
            return View();
        }

    }
}
