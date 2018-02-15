using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IStateInfoDal
    {
        List<StateInfoModelDC> GetStates();

        StateInfoModelDC GetStateById(int id);

        void AddState(StateInfoModelDC obj);

        void UpdateState(int id, StateInfoModelDC obj);

        void DeleteState(int id);
    }
}
