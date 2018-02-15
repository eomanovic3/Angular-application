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
    public class StateInfoController : ApiController
    {
        private readonly StateInfoLogic _stateMethods;

        public StateInfoController(StateInfoLogic stateMethods)
        {
            this._stateMethods = stateMethods;
        }


        // GET: api/State
        public IEnumerable<StateInfoModelDC> Get()
        {
            return _stateMethods.GetStates();
        }

        // GET: api/State/5
        public StateInfoModelDC Get(int id)
        {
            return _stateMethods.GetStateById(id);
        }

        // POST: api/State
        public void Post([FromBody]StateInfoModelDC state)
        {
            _stateMethods.AddState(state);
        }

        // PUT: api/State/5
        public void Put(int id, [FromBody]StateInfoModelDC state)
        {
            _stateMethods.UpdateState(id, state);
        }

        // DELETE: api/State/5
        public void Delete(int id)
        {
            _stateMethods.DeleteState(id);
        }
    }
}
