using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class StateInfoDal : IStateInfoDal
    {
        private APLABDatabaseEntities _db;

        public StateInfoDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }

        public List<StateInfoModelDC> GetStates()
        {
            List<StateInfoModelDC> list = new List<StateInfoModelDC>();
            foreach (StateInfo state in _db.StateInfoes)
            {
                list.Add(MapToStateInfoModelDC(state));
            }
            return list;
        }

        public StateInfoModelDC GetStateById(int id)
        {
            StateInfo obj = _db.StateInfoes.FirstOrDefault(x => x.StateId == id);

            if (obj == null)
            {
                throw new ArgumentException(Messages.StateExceptionGetById);
            }
            else
            {
                return MapToStateInfoModelDC(obj);
            }            
        }

        public void AddState(StateInfoModelDC obj)
        {
            if (obj == null)
                throw new ArgumentException(Messages.StateExceptionAdd); 

            _db.StateInfoes.Add(MapToStateInfo(obj));
            _db.SaveChanges();
        }

        public void UpdateState(int id, StateInfoModelDC obj)
        {
            StateInfo state = _db.StateInfoes.FirstOrDefault(x => x.StateId == id);

            if (state == null)
            {
                throw new ArgumentException(Messages.StateExceptionUpdateById);
            }

            state = MapAndSaveStateInfoModelDCToState(state, obj);
            _db.SaveChanges();
        }

        public void DeleteState(int id)
        {
            StateInfo state = _db.StateInfoes.FirstOrDefault(x => x.StateId == id);

            if (state == null)
            {
                throw new ArgumentException(Messages.StateExceptionDelete);
            }

            foreach (var i in _db.StateInfoes)
            {
                if (i.StateId == id)
                {
                    _db.StateInfoes.Remove(i);
                }
            }
            _db.SaveChanges();
        }
    }
}
