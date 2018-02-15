using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class StateInfoMapper { }
    public partial class StateInfoDal
    {
        public StateInfoModelDC MapToStateInfoModelDC(StateInfo a)
        {
            return new StateInfoModelDC()
            {
                stateId = a.StateId,
                stateCode = a.StateCode,
                stateName = a.StateName
            };
        }
        public StateInfo MapToStateInfo(StateInfoModelDC a)
        {
            return new StateInfo()
            {
                StateId = a.stateId,
                StateCode = a.stateCode,
                StateName = a.stateName
            };
        }

        public StateInfoModelDC MapAndSaveStateToStateInfoModelDC(StateInfoModelDC a, StateInfo b)
        {
            a.stateId = b.StateId;
            a.stateCode = b.StateCode;
            a.stateName = b.StateName;
            return a;
        }

        public StateInfo MapAndSaveStateInfoModelDCToState(StateInfo a, StateInfoModelDC b)
        {
            a.StateId = b.stateId;
            a.StateCode = b.stateCode;
            a.StateName = b.stateName;
            return a;
        }
    }
}
