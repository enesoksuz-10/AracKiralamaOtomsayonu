using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentACar_UI.ActionFilters;

namespace RentACar_UI.Areas.AdminPanel.ActionFilters
{
    [Area("AdminPanel")]
    public class AdminCheckLoginSession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var jsonStr = context.HttpContext.Session.GetString("ActiveAdminUser");
            if (string.IsNullOrEmpty(jsonStr))
            {
                context.Result = new RedirectResult("/AdminPanel/Authentication/LogIn");
            }
        }
    }
}
