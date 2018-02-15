using DAL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICity
    {
        List<CityModelDC> GetCities();

        CityModelDC GetCityById(int id);

        void AddCity(CityModelDC obj);
        void UpdateCity(int id, CityModelDC obj);

        void DeleteCity(int id);
        
    }
}
