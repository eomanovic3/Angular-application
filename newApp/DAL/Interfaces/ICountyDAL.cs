using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICountyDal
    {
        List<CountyModelDC> GetCounties();

        CountyModelDC GetCountyById(int id);

        void AddCounty(CountyModelDC obj);

        void UpdateCounty(int id, CountyModelDC obj);

        void DeleteCounty(int id);
    }
}
