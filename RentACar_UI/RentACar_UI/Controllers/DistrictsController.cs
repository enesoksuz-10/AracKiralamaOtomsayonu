using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;
using RentACar_ModelsLayer.Entities.Concreate;

namespace RentACar_UI.Controllers
{
    public class DistrictsController : Controller
    {
        [HttpPost]
        public JsonResult GetByCities(int id)
        {
            var districtBs = new DistrictBS();
            var districts = districtBs.GetByCities(id);
            if (districts != null)
            {
                return Json(new { Response = true, District = districts });

            }
            else
            {
                return Json(new { Response = false, Message = "Bir Hata oluştu." });
            }
        }
    }
}
