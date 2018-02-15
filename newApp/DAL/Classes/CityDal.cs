using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CityDal : ICityDal
    {
        private APLABDatabaseEntities _db;

        public CityDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }

        public List<CityModelDC> GetCities()
        {
            List<CityModelDC> list = new List<CityModelDC>();
            foreach (City city in _db.Cities)
            {
               list.Add(MapToCityModelDC(city));
            }
            return list;
        }

        public CityModelDC GetCityById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.CityExceptionGetById);

            City obj = _db.Cities.FirstOrDefault(x => x.CityId == id);

            if (obj == null)
            { 
                throw new NullReferenceException(Messages.CityExceptionGetById);
            }
            else
            { 
                return MapToCityModelDC(obj);
            }
           
        }

        public void AddCity(CityModelDC obj)
        {
            foreach (City city in _db.Cities)
            {
                if (city.CityId == obj.cityId)
                {
                    throw new ArgumentOutOfRangeException(Messages.CityExceptionAdd);
                }
            }
            if (obj == null)
                throw new ArgumentOutOfRangeException(Messages.CityExceptionAdd);

            _db.Cities.Add(MapToCity(obj));
            _db.SaveChanges();
        }

        public void UpdateCity(int id, CityModelDC obj)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.CityExceptionUpdateById);

            City city = _db.Cities.FirstOrDefault(x => x.CityId == id);

            if (city == null)
            {
                throw new ArgumentException(Messages.CityExceptionUpdateById);
            }

            city = MapAndSaveCityModelDCToCity(city, obj);
            _db.SaveChanges();
        }

        public void DeleteCity(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.CityExceptionDelete);

            City city = _db.Cities.FirstOrDefault(x => x.CityId == id);

            if (city == null)
            {
                throw new ArgumentException(Messages.CityExceptionDelete);
            }

            foreach (var i in _db.Cities)
            {
                if (i.CityId == id)
                {
                    _db.Cities.Remove(i);
                }
            }
            _db.SaveChanges();
        }
    }
}
