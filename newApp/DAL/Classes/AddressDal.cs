using DC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Reflection;

namespace DAL
{

    public partial class AddressDal : IAddressDal
    {
        private APLABDatabaseEntities _db;

        public AddressDal(APLABDatabaseEntities entities)
        {
            _db = entities;
        }

        public List<AddressModelDC> GetAddresses()
        {
            List<AddressModelDC> list = new List<AddressModelDC>();

            foreach (Address address in _db.Addresses)
            {
                if (address.IsDeleted == false && _db.UserDetails.FirstOrDefault(x => x.UserId == address.UserId).IsDeleted == false)
                {
                    list.Add(MapToAddressModelDC(address));
                }
            }
            return list;
        }

        public AddressModelDC GetAddressById(int id)
        {

            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.AddressExceptionGetById);

            Address obj = _db.Addresses.FirstOrDefault(x => x.AddressId == id);
            if (obj != null)
            {
                return MapToAddressModelDC(obj);
            }
            else
            {

                throw new NullReferenceException(Messages.AddressExceptionGetById);
            }
        }

        public void AddAddress(AddressModelDC obj)
        {
            foreach (Address address in _db.Addresses)
            {
                if (address.AddressId == obj.addressId)
                {
                    throw new ArgumentOutOfRangeException(Messages.AddressExceptionAdd);
                }
            }
            if (obj == null)
            {
                throw new ArgumentOutOfRangeException(Messages.AddressExceptionAdd);
            }
            _db.Addresses.Add(MapToAddress(obj));
            _db.SaveChanges();
        }

        public void UpdateAddress(int id, AddressModelDC obj)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.AddressExceptionUpdateById);

            Address address = _db.Addresses.FirstOrDefault(x => x.AddressId == id);

            if (address == null)
            {
                throw new ArgumentException(Messages.AddressExceptionUpdateById);
            }

            address = MapAndSaveAddressModelDCToAddress(address, obj);
            _db.SaveChanges();
        }

        public void DeleteAddress(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(Messages.AddressExceptionUpdateById);

            Address address = _db.Addresses.FirstOrDefault(x => x.AddressId == id);

            if (address != null)
            {
                foreach (var i in _db.Addresses)
                {
                    if (i.AddressId == id)
                    {
                        _db.Addresses.Remove(i);
                    }
                }
                _db.SaveChanges();
            }
            else
            {
                throw new NullReferenceException(Messages.AddressExceptionDelete);
            }
        }
    }
}
