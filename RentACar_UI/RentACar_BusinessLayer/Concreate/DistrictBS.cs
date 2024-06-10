using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_BusinessLayer.Concreate
{
    public class DistrictBS
    {
        public List<District> GetByCities(int id)
        {
            var repo = new DistrictRepository();
            var districts = repo.GetByCities(id);
            return districts;
        }
    }
}
