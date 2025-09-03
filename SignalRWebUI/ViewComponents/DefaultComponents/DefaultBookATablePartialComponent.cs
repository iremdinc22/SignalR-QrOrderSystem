using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.LayoutComponents
{
    public class DefaultBookATablePartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}