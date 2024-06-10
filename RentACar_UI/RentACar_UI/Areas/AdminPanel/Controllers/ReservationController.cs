using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;
using RentACar_ModelsLayer.Entities.Concreate;
using RentACar_UI.Areas.AdminPanel.ActionFilters;
using RentACar_UI.Areas.AdminPanel.Models;

namespace RentACar_UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AdminCheckLoginSession]
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            var model = new ReservationIndexViewModel();

            var bs = new ReservationBS();

            var reservations = bs.GetAllReservations();

            model.Reservations = reservations;

            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteReservation(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Silme işlemi sırasında bir sorun ile karşılaşıldı." });
            }
            var reservationBs = new ReservationBS();
            reservationBs.Delete(id);
            return Json(new { Result = true, Message = "Rezervasyon silindi." });
        }

        [HttpPost]
        public JsonResult EditReservation(ReservationUpdateDto dto)
        {
            var reservationBs = new ReservationBS();
            var reservationOrjinal = reservationBs.GetById(dto.ReservationID);
            if (reservationOrjinal == null)
            {
                return Json(new { Result = false, Message = "Rezervasyon bulunamadı." });
            }
            reservationOrjinal.ReservationOn = dto.ReservationOn;

            var updateReservation = reservationBs.Update(reservationOrjinal);

            if (updateReservation != null)
            {
                return Json(new { Result = true, Message = "Rezervasyon başarılı bir şekilde güncellendi." });
            }
            else
            {
                return Json(new { Result = false, Message = "Rezervasyon güncellenemedi." });
            }
        }
    }
}
