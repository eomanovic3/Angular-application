using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DC
{
    [DataContract]
    public class UserDetailModelDC
    {
        [DataMember]
        public int userId;

        [DataMember]
        public string firstName;


        [DataMember]
        public string lastName;


        [DataMember]
        public string userName;

        [DataMember]
        public bool isDeleted;

        public  UserDetailModelDC() { }
        public UserDetailModelDC(int userId, string firstName, string lastName, string userName, bool isDeleted)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.isDeleted = isDeleted;
        }
    }
}
