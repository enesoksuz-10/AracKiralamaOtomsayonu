
using RentACar_DataAccessLayer.Context;
using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System.Collections.Generic;

namespace RentACar_BusinessLayer.Concreate
{
    public class VehicleBS
    {
        public List<Vehicle> GetAll(params string[] includeList)
        {
            var repo = new VehicleRepository();
            var listVehicle = repo.GetAllVehicles(includeList);
            return listVehicle;
        }

        public Vehicle GetById(int id, params string[] includeList)
        {
            var repo = new VehicleRepository();
            var vehicle = repo.GetVehicleById(id, includeList);
            return vehicle;
        }
        public Vehicle AddVehicle(Vehicle vehicle)
        {
            var repo = new VehicleRepository();
            var vehicles = repo.Add(vehicle);
            return vehicles;
        }
        public void Delete(int id)
        {
            var repo = new VehicleRepository();
            repo.Delete(id);
        }
        public Vehicle Update(Vehicle vehicle)
        {
            var repo = new VehicleRepository();
            var vehicles = repo.Update(vehicle);
            return vehicles;
        }
        public List<Vehicle> GetFilteredVehicles(VehicleFilterDto filter)
        {
            var repo = new VehicleRepository();
            var filteredVehicles = repo.GetFilteredVehicles(filter);
            return filteredVehicles;
        }
       


    }
}

