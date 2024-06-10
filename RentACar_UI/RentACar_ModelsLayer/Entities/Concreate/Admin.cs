using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_ModelsLayer.Entities.Concreate
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminLastName { get; set; }
        public string AdminPhoto { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
    }
}
