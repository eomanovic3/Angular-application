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
    public class EmailController : ApiController
    {
        private readonly EmailLogic emailMethods;

        public EmailController(EmailLogic _emailMethods)
        {
            emailMethods = _emailMethods;
        }

        [HttpGet]
        // GET: api/Email
        public IEnumerable<EmailModelDC> Get()
        {
            return emailMethods.GetEmails();
        }

        // GET: api/Email/5
        public EmailModelDC Get(int id)
        {
            return emailMethods.GetEmailById(id);
        }

        // POST: api/Email
        public void Post([FromBody]EmailModelDC email)
        {
            emailMethods.AddEmail(email);
        }

        // PUT: api/Email/5
        public void Put(int id, [FromBody]EmailModelDC email)
        {
            emailMethods.UpdateEmail(id, email);
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
            emailMethods.DeleteEmail(id);
        }
    }
}
