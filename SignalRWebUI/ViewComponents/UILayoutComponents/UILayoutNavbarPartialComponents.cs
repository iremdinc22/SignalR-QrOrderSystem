using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.UILayoutComponents
{
    public class UILayoutNavbarPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}