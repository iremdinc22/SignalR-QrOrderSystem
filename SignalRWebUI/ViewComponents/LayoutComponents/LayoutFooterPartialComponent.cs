using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.LayoutComponents
{
    public class LayoutFooterPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}