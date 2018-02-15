using BLL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{

    public class CountyController : ApiController
    {
        private readonly CountyLogic countyMethods;

        public CountyController(CountyLogic _countyMethods)
        {
            countyMethods = _countyMethods;
        }


        // GET: api/County
        public IEnumerable<CountyModelDC> Get()
        {
            return countyMethods.GetCounties();
        }

        // GET: api/County/5
        public CountyModelDC Get(int id)
        {
            return countyMethods.GetCountyById(id);
        }

        // POST: api/County
        public void Post([FromBody]CountyModelDC county)
        {
            countyMethods.AddCounty(county);
        }

        // PUT: api/County/5
        public void Put(int id, [FromBody]CountyModelDC county)
        {
            countyMethods.UpdateCounty(id, county);
        }

        // DELETE: api/County/5
        public void Delete(int id)
        {
            countyMethods.DeleteCounty(id);
        }
    }
}


