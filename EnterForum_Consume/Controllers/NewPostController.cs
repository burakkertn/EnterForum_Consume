using Microsoft.AspNetCore.Mvc;

namespace EnterForum_Consume.Controllers
{
    public class NewPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
