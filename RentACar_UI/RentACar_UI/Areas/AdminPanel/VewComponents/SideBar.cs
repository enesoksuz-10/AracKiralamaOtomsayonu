using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using RentACar_ModelsLayer.Entities.Concreate;

namespace RentACar_UI.Areas.AdminPanel.VewComponents
{
    public class SideBar:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {

            var jsonStr = HttpContext.Session.GetString("ActiveUser");
            Admin admin = null;

            if (!string.IsNullOrEmpty(jsonStr))
            {
                admin = JsonConvert.DeserializeObject<Admin>(jsonStr);
            }
            return View(admin);
        }
    }
}
