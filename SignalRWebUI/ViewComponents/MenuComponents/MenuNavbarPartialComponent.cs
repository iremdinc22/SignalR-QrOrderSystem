using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.MenuComponents
{
    public class MenuNavbarPartialViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}

