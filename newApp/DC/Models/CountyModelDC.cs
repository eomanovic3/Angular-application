using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    [DataContract]
    public class CountyModelDC
    {
        [DataMember]
        public int countyId;

        [DataMember]
        public string countyName;

        [DataMember]
        public int stateId;

        public CountyModelDC() { }

        public CountyModelDC(int countyId, string countyName, int stateId)
        {
            this.countyId = countyId;
            this.countyName = countyName;
            this.stateId = stateId;
        }
    }
}
