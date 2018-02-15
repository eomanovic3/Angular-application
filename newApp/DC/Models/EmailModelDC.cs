using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    [DataContract]
    public class EmailModelDC
    {

        [DataMember]
        public int emailId;

        [DataMember]
        public string emailAddress;

        [DataMember]
        public bool isPrimary;

        [DataMember]
        public int userId;

        [DataMember]
        public bool isDeleted;

        public EmailModelDC() { }
        public EmailModelDC(int emailId, string emailAddress, bool isPrimary, int userId, bool isDeleted)
        {
            this.emailId = emailId;
            this.emailAddress = emailAddress;
            this.isPrimary = isPrimary;
            this.userId = userId;
            this.isDeleted = isDeleted;
        }
    }
}
