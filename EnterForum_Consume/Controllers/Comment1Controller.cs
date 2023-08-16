using EnterForum_Consume.Dtos.Comment;
using EnterForum_Consume.Dtos.Topic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EnterForum_Consume.Controllers
{
    public class Comment1Controller : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Comment1Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //[HttpGet]
        public PartialViewResult AddComment()
        {

            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(string description)
        {
            int id = (int)TempData["idForCommentSport"];
            string controllerName = (string)TempData["ControllerName"];
            CreateCommentDto resultCommentDto = new CreateCommentDto
            {
                topicID = id,
                commentDate = DateTime.Now,
                commentUser = "TESTO",
                commmentContent = "boş",
                descripiton = description,
                commmentState = true
             };
        var client = _httpClientFactory.CreateClient();
        var JsonData = JsonConvert.SerializeObject(resultCommentDto);
        StringContent content = new StringContent(JsonData, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync("http://localhost:5074/api/Comment", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Detail1");
    }
            return View();
}
    }
}

