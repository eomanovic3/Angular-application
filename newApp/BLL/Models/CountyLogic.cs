using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC;
using DAL;

namespace BLL
{
    public class CountyLogic : ICounty
    {
        private readonly CountyDal  _counties;

        public CountyLogic(CountyDal counties)
        {
            _counties = counties;
        }
        public List<CountyModelDC> GetCounties()
        {
            return _counties.GetCounties();
        }

        public CountyModelDC GetCountyById(int id)
        {
            if(id < 0)
                throw new ArgumentException(Messages.CountyExceptionGetById);
            return _counties.GetCountyById(id);
        }

        public void AddCounty(CountyModelDC obj)
        {
            foreach (CountyModelDC county in _counties.GetCounties())
            {
                if (county.countyId == obj.countyId)
                {
                    throw new ArgumentException(Messages.CountyExceptionAdd);
                }
            }
            this._counties.AddCounty(obj);
        }


        public void DeleteCounty(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException(Messages.CountyExceptionDelete);
            }

            foreach (CountyModelDC county in _counties.GetCounties())
            {
                if (county.countyId == id)
                {
                    _counties.DeleteCounty(id);
                }
            }
        }

        public void UpdateCounty(int id, CountyModelDC obj)
        {
            if (id < 0)
                throw new ArgumentException(Messages.CountyExceptionUpdateById);
            this._counties.UpdateCounty(id, obj);
        }
    }
}
