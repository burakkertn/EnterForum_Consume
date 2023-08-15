using Microsoft.AspNetCore.Mvc;

namespace EnterForum_Consume.ViewComponents.Default
{
    public class _Navbar2Partial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
