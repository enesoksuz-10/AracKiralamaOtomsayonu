using Microsoft.EntityFrameworkCore;
using RentACar_DataAccessLayer.Context;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_DataAccessLayer.Repository
{
    public class ContactRepository
    {
        public Contact Add(Contact contact)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cont = cnt.Contacts.Add(contact);
                cnt.SaveChanges();
                return cont.Entity;
            }

        }
        public List<Contact> GetAllContact(params string[] includeList)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<Contact> dbSet = cnt.Contacts;

                if (includeList != null && includeList.Length > 0)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        dbSet = dbSet.Include(includeList[i]);
                    }
                }
                var list = dbSet.ToList();
                return list;
            }

        }
        public Contact GetById(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cont = cnt.Contacts.SingleOrDefault(x => x.ContactID == id);
                return cont;
            }
        }
        public Contact Update(Contact contact)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var cont = cnt.Contacts.Update(contact);
                cnt.SaveChanges();
                return cont.Entity;
            }

        }
    }
}
