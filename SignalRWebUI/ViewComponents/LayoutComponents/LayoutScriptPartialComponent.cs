using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.LayoutComponents
{
    public class LayoutScriptPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}

