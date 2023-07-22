using Microsoft.AspNetCore.Mvc;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class HomePageTrailer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
