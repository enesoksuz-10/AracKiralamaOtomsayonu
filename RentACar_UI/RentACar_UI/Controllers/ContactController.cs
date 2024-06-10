using Microsoft.AspNetCore.Mvc;
using RentACar_BusinessLayer.Concreate;
using RentACar_ModelsLayer.Entities.Concreate;
using RentACar_UI.Models;

namespace RentACar_UI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddContact(ContactAddDto dto)
        {

            var contact = new Contact();
            contact.ContactName = dto.ContactName;
            contact.ContactKonu = dto.ContactKonu;
            contact.ContactEposta = dto.ContactEposta;
            contact.ContactMessage = dto.ContactMessage;
            // Dto Nesne Mapping
            // Bs ye Add fonk. gönder --> dataAccess(repo) 
            // Sonucuna göre uyarı ver
            var contactBS = new ContactBS();
            var insertedContact = contactBS.AddContact(contact);

            if (insertedContact != null)
            {
                return Json(new { Result = true, BasariliMi = true, Message = "Mesajınız Başarılı Bir Şekilde Gönderildi. Anasayfaya Yönlendiriliyorsunuz." });
            }
            else
            {
                return Json(new { Result = false, BasariliMi = false, Message = "Mesajınız Gönderilirken Bir Sorun Oluştu." });

            }


        }
    }
}
