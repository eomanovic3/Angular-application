using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newAppLibrary
{
    public class Address
    {
        public int id;
        public string address1;
        public string address2;
        public string city;
        public string county;
        public string state;

        public Address()
        {
        }

        public Address(int id, string address1, string address2, string city, string county, string state)
        {
            this.id = id;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.county = county;
            this.state = state;
        }
    }
}
