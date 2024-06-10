using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_ModelsLayer.Entities.Concreate
{
    public class District
    {
        public int DistrictID { get; set; }
        public int CityID { get; set; }
        public string DistrictName { get; set; }
    }
}
