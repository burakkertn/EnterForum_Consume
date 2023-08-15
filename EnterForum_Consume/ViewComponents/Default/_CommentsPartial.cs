using EnterForum_Consume.Dtos.Category;
using EnterForum_Consume.Dtos.Comment;
using EnterForum_Consume.ViewCompanent.Default;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnterForum_Consume.ViewComponents.Default
{
    public class _CommentsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5074/api/Comment/GetTopicById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }    
        }
}
