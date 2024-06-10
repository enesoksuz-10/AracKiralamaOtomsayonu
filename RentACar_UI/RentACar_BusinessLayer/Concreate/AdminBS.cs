using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_BusinessLayer.Concreate
{
    public class AdminBS
    {
        public Admin LogIn(string UserName, string Password)
        {
            var AdminRepo = new AdminRepository();
            var admn = AdminRepo.GetUserNamePassword(UserName, Password);
            return admn;
        }

        public List<Admin> GetAll(params string[] includeList)
        {
            var repo = new AdminRepository();
            var listAdmin = repo.GetAllAdmins(includeList);
            return listAdmin;
        }
    }
}
