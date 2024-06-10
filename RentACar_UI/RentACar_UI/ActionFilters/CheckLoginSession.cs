using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RentACar_UI.ActionFilters
{
    public class CheckLoginSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var jsonStr = context.HttpContext.Session.GetString("ActiveUser");
            if (string.IsNullOrEmpty(jsonStr))
            {
                context.Result = new RedirectResult("/Authentication/LogIn");
            }
        }
    }
}
