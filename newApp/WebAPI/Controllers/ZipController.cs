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
    public class ZipController : ApiController
    {
        public readonly ZipLogic zipCodeMethods;
        public ZipController(ZipLogic _zipCodeMethods)
        {
            zipCodeMethods = _zipCodeMethods;
        }

      
        // GET: api/ZipCode
        public IEnumerable<ZipModelDC> Get()
        {
            return zipCodeMethods.GetZips();
        }

        // GET: api/ZipCode/5
        public ZipModelDC Get(int id)
        {
            return zipCodeMethods.GetZipById(id);
        }

        // POST: api/ZipCode
        public void Post([FromBody]ZipModelDC zipCode)
        {
            zipCodeMethods.AddZip(zipCode);
        }

        // PUT: api/ZipCode/5
        public void Put(int id, [FromBody]ZipModelDC zipCode)
        {
            zipCodeMethods.UpdateZip(id, zipCode);
        }

        // DELETE: api/ZipCode/5
        public void Delete(int id)
        {
            zipCodeMethods.DeleteZip(id);
        }
    }
}

