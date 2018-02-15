using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class AddressMapper { }
    public partial class AddressDal
    { 
        
        public AddressModelDC MapToAddressModelDC(Address a)
        {
            return new AddressModelDC()
            {
                addressId = a.AddressId,
                address1 = a.Address1,
                address2 = a.Address2,
                zipId = a.ZipId,
                userId =a.UserId,
                isDeleted = a.IsDeleted              
            };            
        }
        public Address MapToAddress(AddressModelDC a)
        {
            return new Address()
            {
               //AddressId = a.addressId,
               Address1 = a.address1,
               Address2 = a.address2,
               ZipId = a.zipId,
               UserId = a.userId,
               IsDeleted = a.isDeleted
            };
        }

        public AddressModelDC MapAndSaveAddressToAddressModelDC(AddressModelDC a, Address b)
        {
            a.addressId = b.AddressId;
            a.address1 = b.Address1;
            a.address2 = b.Address2;
            a.userId = b.UserId;
            a.zipId = b.ZipId;
            a.isDeleted = b.IsDeleted;
            return a;
        }

        public Address MapAndSaveAddressModelDCToAddress(Address a, AddressModelDC b)
        {
            a.AddressId = b.addressId;
            a.Address1 = b.address1;
            a.Address2 = b.address2;
            a.ZipId = b.zipId;
            a.UserId = b.userId;
            a.IsDeleted = b.isDeleted;
            return a;
        }
    }
}