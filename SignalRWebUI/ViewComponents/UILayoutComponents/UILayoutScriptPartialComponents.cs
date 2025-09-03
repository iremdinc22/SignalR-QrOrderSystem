using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.UILayoutComponents
{
    public class UILayoutScriptPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}