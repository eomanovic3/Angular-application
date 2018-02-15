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
    [Route("api/city")]
    public class CityController : ApiController
    {
        private readonly CityLogic cityMethods;
        
        public CityController(CityLogic _cityMethods)
        {
            cityMethods = _cityMethods;
        }

      
        // GET: api/City
        public IEnumerable<CityModelDC> Get()
        {
            return cityMethods.GetCities();
        }

        // GET: api/City/5
        public CityModelDC Get(int id)
        {
            return cityMethods.GetCityById(id);
        }

        // POST: api/City
        public void Post([FromBody]CityModelDC city)
        {
            cityMethods.AddCity(city);
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody]CityModelDC city)
        {
            cityMethods.UpdateCity(id, city);
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
            cityMethods.DeleteCity(id);
        }
    }
}
