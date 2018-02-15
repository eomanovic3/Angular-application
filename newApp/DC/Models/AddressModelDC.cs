using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    [DataContract]
    public class AddressModelDC
    {
        [DataMember]
        public int addressId;

        [DataMember]
        public string address1;

        [DataMember]
        public string address2;

        [DataMember]
        public int zipId;

        [DataMember]
        public int userId;

        [DataMember]
        public bool isDeleted;
        

        public AddressModelDC() { }
        public AddressModelDC(int addressId, string address1, string address2, int zipId, int userId, bool isDeleted)
        {
            this.addressId = addressId;
            this.address1 = address1;
            this.address2 = address2;
            this.zipId = zipId;
            this.userId = userId;
            this.isDeleted = isDeleted;
        }

       
    }
}