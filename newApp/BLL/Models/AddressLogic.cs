using System;
using DAL;
using System.Collections.Generic;
using DC;

namespace BLL
{
    public class AddressLogic : IAddress
    {
        private readonly IAddressDal _addressDAL;
        public AddressLogic(IAddressDal addressDAL)
        {
            _addressDAL = addressDAL;
        }

        public void AddAddress(AddressModelDC obj)
        {
            if(obj == null)
            {
                throw new ArgumentOutOfRangeException(Messages.AddressExceptionAdd);
            }
            foreach (AddressModelDC address in _addressDAL.GetAddresses())
            {
                if (address.addressId == obj.addressId)
                {
                    throw new ArgumentException(Messages.AddressExceptionAdd);
                }
            }
            this._addressDAL.AddAddress(obj);
        }

       public void DeleteAddress(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException(Messages.AddressExceptionDelete);
            }
            foreach (AddressModelDC address in _addressDAL.GetAddresses())
            {
                if (address.addressId == id)
                {
                    _addressDAL.DeleteAddress(id);
                }              
            }         
        }

        public AddressModelDC GetAddressById(int id)
        {
            if (id < 0)
                throw new ArgumentException(Messages.AddressExceptionGetById);
            return _addressDAL.GetAddressById(id);
        }

        public List<AddressModelDC> GetAddresses()
        {
            return _addressDAL.GetAddresses();
        }

        public void UpdateAddress(int id, AddressModelDC obj)
        {
            if (id < 0)
                throw new ArgumentException(Messages.AddressExceptionGetById);
            this._addressDAL.UpdateAddress(id, obj);
        }
    }
}
