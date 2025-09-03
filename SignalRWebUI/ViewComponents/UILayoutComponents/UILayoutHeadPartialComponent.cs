using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.UILayoutComponents
{
    public class UILayoutHeadPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}