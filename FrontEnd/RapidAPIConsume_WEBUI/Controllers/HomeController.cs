using Microsoft.AspNetCore.Mvc;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }

        public PartialViewResult CustomerLayoutHeader()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutHeaderInBody()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutFooter()
        {
            return PartialView();
        }

        public PartialViewResult CustomerLayoutScripts()
        {
            return PartialView();
        }

    }
}
