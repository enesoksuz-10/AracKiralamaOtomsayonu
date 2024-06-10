using Microsoft.AspNetCore.Mvc;

namespace RentACar_UI.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
