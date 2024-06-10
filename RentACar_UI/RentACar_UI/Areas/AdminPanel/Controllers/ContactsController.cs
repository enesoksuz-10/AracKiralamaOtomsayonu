using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;
using RentACar_UI.Areas.AdminPanel.ActionFilters;
using RentACar_UI.Areas.AdminPanel.Models;

namespace RentACar_UI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [AdminCheckLoginSession]
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            var contBS = new ContactBS();
            var model = new ContactIndexVıewModel
            {
                ListContact= contBS.GetAllContact()
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult DeleteContact(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Silme işlemi sırasında bir sorun ile karşılaşıldı." });
            }
            var contactBs = new ContactBS();
            contactBs.Delete(id);
            return Json(new { Result = true, Message = "İletişim Mesajı Silindi." });
        }

        [HttpGet]
        public JsonResult GetContactById(int id)
        {
            if (id <= 0)
            {
                return Json(new { Result = false, Message = "Geçersiz ID." });
            }
            var contactBs = new ContactBS();
            var contact = contactBs.GetById(id);
            return Json(new { Result = true, Contact = new { contact.ContactID, contact.ContactRead } });
        }

        [HttpPost]
        public JsonResult EditContact(ContactUpdateDto dto)
        {
            var contactBs = new ContactBS();
            var contactOrjinal = contactBs.GetById(dto.ContactID);
            if (contactOrjinal == null)
            {
                return Json(new { Result = false, Message = "Rezervasyon bulunamadı." });
            }
            contactOrjinal.ContactRead = dto.ContactRead;

            var updateContact = contactBs.Update(contactOrjinal);

            if (updateContact != null)
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
