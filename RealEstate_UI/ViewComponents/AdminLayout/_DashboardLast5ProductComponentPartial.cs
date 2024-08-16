using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI.ViewComponents.AdminLayout
{
    public class _DashboardLast5ProductComponentPartial:ViewComponent
    {
        public async Task< IViewComponentResult> InvokAsync()
        {
            return View();
        }
    }
}
