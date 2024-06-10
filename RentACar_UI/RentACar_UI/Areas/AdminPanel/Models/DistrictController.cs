using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;

public class DistrictController : Controller
{
    [HttpPost]
    public JsonResult GetByCities(int id)
    {
        try
        {
            var districtBS = new DistrictBS();
            var districts = districtBS.GetByCities(id);
            if (districts != null)
            {
                return Json(new { Response = true, District = districts });
            }
            else
            {
                return Json(new { Response = false, Message = "Bir Hata oluştu." });
            }
        }
        catch (Exception ex)
        {
            // Hata mesajını logla
            Console.WriteLine(ex.Message);
            return Json(new { Response = false, Message = "Bir Hata oluştu." });
        }
    }
}
