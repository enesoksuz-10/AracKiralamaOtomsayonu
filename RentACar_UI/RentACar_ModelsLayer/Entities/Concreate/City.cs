using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_ModelsLayer.Entities.Concreate
{
    public class City
    {
        public int CityID { get; set; }
        public string? CityName { get; set; }
        public int PlateNumber { get; set; }
        public int PhoneCode { get; set; }
        public int RowNumber { get; set; }
    }
}
