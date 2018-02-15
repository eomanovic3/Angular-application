using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    [DataContract]
    public class CityModelDC
    {
        [DataMember]
        public int cityId;

        [DataMember]
        public string cityName;

        [DataMember]
        public int countyId;

        public CityModelDC() { }

        public CityModelDC(int cityId, string cityName, int countyId)
        {
            this.cityId = cityId;
            this.cityName = cityName;
            this.countyId = countyId;
        }
    }
}
