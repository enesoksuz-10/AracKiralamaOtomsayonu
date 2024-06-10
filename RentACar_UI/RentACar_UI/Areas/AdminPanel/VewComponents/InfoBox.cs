using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using RentACar_UI.Areas.AdminPanel.Models;

namespace RentACar_UI.Areas.AdminPanel.ViewComponents
{
    public class InfoBox : ViewComponent
    {
        public IViewComponentResult Invoke(string BackGround, string Icon, string Count, string Title)
        {
            var model = new InfoBoxParameter
            {
                Background = BackGround,
                Icon = Icon,
                Count = Count,
                Title = Title
            };

            return View(model);
        }
    }
}
