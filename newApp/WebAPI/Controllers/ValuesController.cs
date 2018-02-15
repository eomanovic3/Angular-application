using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET: api/values  
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Afraz", "Afreen", "ASHA", "KATHER", "Shanu" };
        }
    }
}