using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.LayoutComponents
{
    public class LayoutNavbarPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}

