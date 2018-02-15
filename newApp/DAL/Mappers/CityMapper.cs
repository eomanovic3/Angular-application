using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CityDal
    {
        public CityModelDC MapToCityModelDC(City a)
        {
            return new CityModelDC()
            {
                cityId = a.CityId,
                cityName = a.CityName,
                countyId = a.CountyId
            };
        }
        public City MapToCity(CityModelDC a)
        {
            return new City()
            {
                CityId = a.cityId,
                CityName = a.cityName,
                CountyId = a.countyId
            };
        }

        public CityModelDC MapAndSaveCityToCityModelDC(CityModelDC a, City b)
        {
            a.cityId = b.CityId;
            a.cityName = b.CityName;
            a.countyId = b.CountyId;
            return a;
        }

        public City MapAndSaveCityModelDCToCity(City a, CityModelDC b)
        {
            a.CityId = b.cityId;
            a.CityName = b.cityName;
            a.CountyId = b.countyId;
            return a;
        }
    }
}
