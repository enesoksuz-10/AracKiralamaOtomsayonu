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
    public class AdminRepository
    {
        public Admin GetUserNamePassword(string UserName, string Password)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var Admn = cnt.Admins.SingleOrDefault(x => x.AdminUserName == UserName && x.AdminPassword == Password);
                return Admn;
            }

        }
        public List<Admin> GetAllAdmins(params string[] includeList)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<Admin> dbSet = cnt.Admins;

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
    }
}
