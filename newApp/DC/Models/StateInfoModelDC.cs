using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    
    [DataContract]
    public class StateInfoModelDC
    {
        [DataMember]
        public int stateId;

        [DataMember]
        public string stateCode;


        [DataMember]
        public string stateName;

        public StateInfoModelDC() { }
        public StateInfoModelDC(int stateId, string stateCode, string stateName)
        {
            this.stateId = stateId;
            this.stateCode = stateCode;
            this.stateName = stateName;
        }
    }
}
