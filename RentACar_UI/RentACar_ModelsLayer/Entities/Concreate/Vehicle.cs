using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_ModelsLayer.Entities.Concreate
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string? VehicleBrand { get; set; }
        public string? CityName { get; set; }
        public string? District { get; set; }
        public string? VehicleModel { get; set; }
        public string? VehicleColor { get; set; }
        public string? VehicleFuel { get; set; }
        public string? VehicleFuelAmount { get; set; }
        public string? VehiclePhoto { get; set; }
        public int VehiclePrice { get; set; }
        public bool? VehicleActive { get; set; }
    }
}
