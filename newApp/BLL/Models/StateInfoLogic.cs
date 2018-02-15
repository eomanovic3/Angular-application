using DAL;
using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StateInfoLogic : IStateInfo
    {
        private readonly StateInfoDal _states;

        public StateInfoLogic(StateInfoDal states)
        {
            _states = states;
        }
        public List<StateInfoModelDC> GetStates()
        {
            return _states.GetStates();
        }

        public StateInfoModelDC GetStateById(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.StateExceptionGetById);
            return _states.GetStateById(id);
        }

        public void AddState(StateInfoModelDC obj)
        {
            foreach (StateInfoModelDC state in _states.GetStates())
            {
                if (state.stateId == obj.stateId)
                {
                    throw new ArgumentException(Messages.StateExceptionAdd);
                }
            }
            this._states.AddState(obj);
        }

        public void UpdateState(int id, StateInfoModelDC obj)
        {
            if (id < 0)
                throw new ArgumentException(Messages.StateExceptionUpdateById);
            this._states.UpdateState(id, obj);
        }

        public void DeleteState(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.StateExceptionDelete);
            foreach (StateInfoModelDC state in _states.GetStates())
            {
                if (state.stateId == id)
                {
                    _states.DeleteState(id);
                }
            }
        }
    }
}
