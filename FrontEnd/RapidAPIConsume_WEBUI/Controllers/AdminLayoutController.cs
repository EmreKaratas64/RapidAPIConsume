using Microsoft.AspNetCore.Mvc;

namespace RapidAPIConsume_WEBUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminHeader()
        {
            return PartialView();
        }

        public PartialViewResult AdminNavHeader()
        {
            return PartialView();
        }

        public PartialViewResult AdminSideBar()
        {
            return PartialView();
        }

        public PartialViewResult AdminFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminScripts()
        {
            return PartialView();
        }

        public IActionResult Test()
        {
            return View();
        }

    }
}
