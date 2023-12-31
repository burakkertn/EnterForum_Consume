﻿using EnterForum_Consume.Dtos.Topic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnterForum_Consume.Controllers
{
    public class MobilController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MobilController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            TempData["id"] = id;
            return View();
        }
        public async Task<IActionResult> Detail1(int id)
        {
            TempData["idForCommentMobil"] = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5074/api/Topic/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultTopicDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
