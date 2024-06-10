using RentACar_DataAccessLayer.Context;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_DataAccessLayer.Repository
{
    public class DistrictRepository
    {
        public List<District> GetByCities(int id)
        {
            using (RentacarContext cnt = new RentacarContext())
            {
                IQueryable<District> dbSet = cnt.Districts;
                return dbSet.Where(x => x.CityID == id).ToList();
            }
        }
    }
}
