using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.LayoutComponents
{
    public class LayoutSidebarPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}


