using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_ModelsLayer.Entities.Concreate
{
    public class Contact
    {
        public int ContactID { get; set; }
        public String? ContactName { get; set; }
        public String? ContactEposta { get; set; }
        public String? ContactKonu { get; set; }
        public String? ContactMessage { get; set; }
        public bool ContactRead { get; set; }
    }
}
