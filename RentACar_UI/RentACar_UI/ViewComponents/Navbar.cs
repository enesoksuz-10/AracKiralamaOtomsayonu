using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

public class Navbar : ViewComponent
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Navbar(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ViewViewComponentResult Invoke()
    {
        var activeUserJson = _httpContextAccessor.HttpContext.Session.GetString("ActiveUser");

        if (!string.IsNullOrEmpty(activeUserJson))
        {
            JObject userObject = JObject.Parse(activeUserJson);
            string customerName = userObject["CustomerName"].ToString();
            string customerLastName = userObject["CustomerLastName"].ToString();
            ViewBag.IsActiveUser = true;
            ViewBag.ActiveUserName = customerName;
            ViewBag.ActiveLastName = customerLastName;
        }
        else
        {
            ViewBag.IsActiveUser = false;
            ViewBag.ActiveUserName = null;
        }

        return View();
    }
}
