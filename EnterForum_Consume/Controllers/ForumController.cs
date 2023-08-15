using Microsoft.AspNetCore.Mvc;

namespace EnterForum_Consume.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Forum/{name}/{id}")]
        public IActionResult Index(int id, string name)
        {
            return View();
        }
    }
}
