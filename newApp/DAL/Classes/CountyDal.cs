using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CountyDal : ICountyDal
    {
        private APLABDatabaseEntities _db;

        public CountyDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }

        public List<CountyModelDC> GetCounties()
        {
            List<CountyModelDC> list = new List<CountyModelDC>();
            foreach (County county in _db.Counties)
            {
                list.Add(MapToCountyModelDC(county));
            }

            return list;
        }

        public CountyModelDC GetCountyById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.CountyExceptionUpdateById);

            County obj = _db.Counties.FirstOrDefault(x => x.CountyId == id);

            if (obj == null)
            {
                throw new NullReferenceException(Messages.CountyExceptionGetById);
            }
            else
            {
                return MapToCountyModelDC(obj);
            }            
        }

        public void AddCounty(CountyModelDC obj)
        {
            if (obj == null)
                throw new ArgumentOutOfRangeException(Messages.CountyExceptionAdd);

            _db.Counties.Add(MapToCounty(obj));
            _db.SaveChanges();
        }

        public void UpdateCounty(int id, CountyModelDC obj)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.CountyExceptionUpdateById);

            var county = _db.Counties.FirstOrDefault(x => x.CountyId == id);

            if (county == null)
            {
                throw new NullReferenceException(Messages.CountyExceptionUpdateById);
            }

            county = MapAndSaveCountyModelDCToCounty(county, obj);
            _db.SaveChanges();
        }

        public void DeleteCounty(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.CountyExceptionDelete);

            var county = _db.Counties.FirstOrDefault(x => x.CountyId == id);

            if (county == null)
            {
                throw new NullReferenceException(Messages.CountyExceptionDelete);
            }

            _db.SaveChanges();
        }
    }
}
