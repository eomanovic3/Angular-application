using BLL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    public class AddressController : ApiController
    {
        private readonly AddressLogic addressMethods;
        public AddressController(AddressLogic _addressMethods)
        {
            addressMethods = _addressMethods;
        }

        // GET api/Address
        public IEnumerable<AddressModelDC> Get()
        {
            return addressMethods.GetAddresses();
        }
   
        // GET api/Address/5
        public AddressModelDC Get(int id)
        {
            return addressMethods.GetAddressById(id);
        }
       
        // POST: api/Address
        public void Post([FromBody]AddressModelDC address)
        {
            addressMethods.AddAddress(address);
        }

        // PUT: api/Address/5
        public void Put(int id, [FromBody]AddressModelDC address)
        {
            addressMethods.UpdateAddress(id, address);
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
            addressMethods.DeleteAddress(id);
        }
    }
}
