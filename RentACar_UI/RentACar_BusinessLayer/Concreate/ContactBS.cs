using RentACar_DataAccessLayer.Context;
using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_BusinessLayer.Concreate
{
    public class ContactBS
    {
        public Contact AddContact(Contact contact)
        {
            var repo = new ContactRepository();
            var contacts = repo.Add(contact);
            return contacts;
        }
        public List<Contact> GetAllContact(params string[] includeList)
        {
            var repo = new ContactRepository();
            var listContact = repo.GetAllContact(includeList);
            return listContact;
        }

        public void Delete(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cntc = GetById(id);
                cnt.Contacts.Remove(cntc);
                cnt.SaveChanges();

            }
        }
        public Contact GetById(int id)
        {
            var repo = new ContactRepository();
            var contacts = repo.GetById(id);
            return contacts;
        }
        public Contact Update(Contact contact)
        {
            var repo = new ContactRepository();
            var contacts = repo.Update(contact);
            return contacts;
        }
    }
}
