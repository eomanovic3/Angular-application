using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC;
using DAL;

namespace BLL
{
    public class CityLogic : ICity
    {

        private readonly CityDal _cityDAL;
        public CityLogic(CityDal cityDAL)
        {
            _cityDAL = cityDAL;
        }

        public void AddCity(CityModelDC obj)
        {
            foreach (CityModelDC city in _cityDAL.GetCities())
            {
                if (city.cityId == obj.cityId)
                {
                    throw new ArgumentException(Messages.CityExceptionAdd);
                }
            }
            this._cityDAL.AddCity(obj);
        }

       
        public void DeleteCity(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException(Messages.CityExceptionDelete);
            }

            foreach (CityModelDC city in _cityDAL.GetCities())
            {
                if (city.cityId == id)
                {
                    _cityDAL.DeleteCity(id);
                }
            }
           
        }

        public List<CityModelDC> GetCities()
        {
            return _cityDAL.GetCities();
        }

        public CityModelDC GetCityById(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.CityExceptionGetById);
            return _cityDAL.GetCityById(id);
        }

        public void UpdateCity(int id, CityModelDC obj)
        {
            if (id < 0)
                throw new ArgumentException(Messages.CityExceptionUpdateById);
            this._cityDAL.UpdateCity(id, obj);
        }
    }
}
