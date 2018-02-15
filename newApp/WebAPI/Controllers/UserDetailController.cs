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
    public class UserDetailController : ApiController
    {
        private readonly UserDetailLogic userDetailMethods;

        public UserDetailController(UserDetailLogic _userDetailMethods)
        {
            userDetailMethods = _userDetailMethods;
        }


        // GET: api/UserDetail
        public IEnumerable<UserDetailModelDC> Get()
        {
            return userDetailMethods.GetUsers();
        }

        // GET: api/UserDetail/5
        public UserDetailModelDC Get(int id)
        {
            return userDetailMethods.GetUserById(id);
        }

        // POST: api/UserDetail
        public void Post([FromBody]UserDetailModelDC userDetail)
        {
            userDetailMethods.AddUser(userDetail);
        }

        // PUT: api/UserDetail/5
        public void Put(int id, [FromBody]UserDetailModelDC userDetail)
        {
            userDetailMethods.UpdateUser(id, userDetail);
        }

        // DELETE: api/UserDetail/5
        public void Delete(int id)
        {
            userDetailMethods.DeleteUser(id);
        }
    }
}


