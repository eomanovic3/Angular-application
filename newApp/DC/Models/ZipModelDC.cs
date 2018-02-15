using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    [DataContract]
    public class ZipModelDC
    {
        [DataMember]
        public int zipId;

        [DataMember]
        public string zipCode;


        [DataMember]
        public int cityId;

        public ZipModelDC() { }

        public ZipModelDC(int zipId, string zipCode, int cityId)
        {
            this.zipId = zipId;
            this.zipCode = zipCode;
            this.cityId = cityId;
        }
    }
}
