using EnterForum_Consume.Dtos.Comment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnterForum_Consume.Controllers
{
    public class DetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
    }
}