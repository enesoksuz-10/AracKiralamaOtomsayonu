using RentACar_DataAccessLayer.Repository;
using RentACar_ModelsLayer.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_BusinessLayer.Concreate
{
    public class CityBS
    {
        public List<City> GetAllCities(params string[] includeList)
        {
            var repo = new CityRepository();
            var cities = repo.GetAllCities(includeList);
            return cities;
        }

    }
}
