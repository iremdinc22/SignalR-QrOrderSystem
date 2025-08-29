using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.LayoutComponents
{
    public class LayoutHeaderPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}