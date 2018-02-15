using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class CountyMapper { }
    public partial class CountyDal
    {

        public CountyModelDC MapToCountyModelDC(County a)
        {
            return new CountyModelDC()
            {
                countyId = a.CountyId,
                countyName = a.CountyName,
                stateId = a.StateId
            };
        }
        public County MapToCounty(CountyModelDC a)
        {
            return new County()
            {
                CountyId = a.countyId,
                CountyName = a.countyName,
                StateId = a.stateId
            };
        }

        public CountyModelDC MapAndSaveCountyToCountyModelDC(CountyModelDC a, County b)
        {
            a.countyId = b.CountyId;
            a.countyName = b.CountyName;
            a.stateId = b.StateId;
            return a;
        }

        public County MapAndSaveCountyModelDCToCounty(County a, CountyModelDC b)
        {
            a.CountyId = b.countyId;
            a.CountyName = b.countyName;
            a.StateId = b.stateId;
            return a;
        }
    }
}
