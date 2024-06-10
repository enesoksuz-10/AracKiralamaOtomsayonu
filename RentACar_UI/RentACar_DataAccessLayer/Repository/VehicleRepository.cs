
using Microsoft.EntityFrameworkCore;
using RentACar_DataAccessLayer.Context;
using RentACar_ModelsLayer.Entities.Concreate;
using System.Collections.Generic;
using System.Linq;

namespace RentACar_DataAccessLayer.Repository
{
    public class VehicleRepository
    {
        public List<Vehicle> GetAllVehicles(params string[] includeList)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<Vehicle> dbSet = cnt.Vehicles;

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
        public Vehicle GetVehicleById(int id, params string[] includeList)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<Vehicle> dbSet = cnt.Vehicles;

                if (includeList != null && includeList.Length > 0)
                {
                    for (int i = 0; i < includeList.Length; i++)
                    {
                        dbSet = dbSet.Include(includeList[i]);
                    }
                }

                var vehicle = dbSet.SingleOrDefault(v => v.VehicleID == id);
                return vehicle;
            }
        }
        public Vehicle GetById(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var veh = cnt.Vehicles.SingleOrDefault(x => x.VehicleID == id);
                return veh;
            }
        }
        public Vehicle Add(Vehicle vehicle)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var veh = cnt.Vehicles.Add(vehicle);
                cnt.SaveChanges();
                return veh.Entity;
            }

        }
        public void Delete(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var veh = GetById(id);
                cnt.Vehicles.Remove(veh);
                cnt.SaveChanges();

            }

        }
        public Vehicle Update(Vehicle vehicle)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                var prd = cnt.Vehicles.Update(vehicle);
                cnt.SaveChanges();
                return prd.Entity;
            }

        }

        public List<Vehicle> GetFilteredVehicles(VehicleFilterDto filter)
        {
            using (var cnt = new RentacarContext())
            {
                IQueryable<Vehicle> query = cnt.Vehicles;

                if (filter.VehicleBrand != null && filter.VehicleBrand.Any())
                {
                    query = query.Where(v => filter.VehicleBrand.Contains(v.VehicleBrand));
                }

                if (filter.VehicleFuel != null && filter.VehicleFuel.Any())
                {
                    query = query.Where(v => filter.VehicleFuel.Contains(v.VehicleFuel));
                }

                if (filter.VehicleColor != null && filter.VehicleColor.Any())
                {
                    query = query.Where(v => filter.VehicleColor.Contains(v.VehicleColor));
                }

                if (filter.MinPrice.HasValue)
                {
                    query = query.Where(v => v.VehiclePrice >= filter.MinPrice.Value);
                }

                if (filter.MaxPrice.HasValue)
                {
                    query = query.Where(v => v.VehiclePrice <= filter.MaxPrice.Value);
                }

                return query.ToList();
            }
        }
    }
}
